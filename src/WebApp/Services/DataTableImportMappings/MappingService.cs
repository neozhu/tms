﻿



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Repository.Pattern.Ef6;
using Repository.Pattern.Repositories;
using Service.Pattern;
using WebApp.Models;
using Z.EntityFramework.Plus;

namespace WebApp.Services
{
  public class DataTableImportMappingService : Service<DataTableImportMapping>, IDataTableImportMappingService
  {

    private readonly IRepositoryAsync<DataTableImportMapping> _repository;
    public DataTableImportMappingService(IRepositoryAsync<DataTableImportMapping> repository)
        : base(repository) => this._repository = repository;




    public IEnumerable<EntityInfo> GetAssemblyEntities()
    {
      var list = new List<EntityInfo>();
      var asm = Assembly.GetExecutingAssembly();
      list = asm.GetTypes()
             .Where(type => typeof(Entity).IsAssignableFrom(type))
             .SelectMany(type => type.GetProperties(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
             .Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any())
             .Select(x => new EntityInfo { EntitySetName = x.DeclaringType.Name, FieldName = x.Name, FieldTypeName = x.PropertyType.Name, IsRequired = x.GetCustomAttributes().Where(f => f.TypeId.ToString().IndexOf("Required") >= 0).Any() })
             .OrderBy(x => x.EntitySetName).ThenBy(x => x.FieldName).ToList();

      return list;
    }


    public void GenerateByEnityName(string entityName)
    {

      var asm = Assembly.GetExecutingAssembly();
      var list = asm.GetTypes()
             .Where(type => typeof(Entity).IsAssignableFrom(type))
             .SelectMany(type => type.GetProperties(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
             .Where(m => m.DeclaringType.Name == entityName &&
                         m.PropertyType.BaseType != typeof(Entity) &&
                       !m.GetCustomAttributes(
                           typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute),
                           true).Any()
                   )
             .Select(x =>
                      new EntityInfo
                      {
                        EntitySetName = x.DeclaringType.Name,
                        FieldName = x.Name,
                        FieldTypeName = x.PropertyType.Name,
                        DefaultValue = ( x.GetCustomAttribute(typeof(DefaultValueAttribute)) != null ? ( x.GetCustomAttribute(typeof(DefaultValueAttribute)) as DefaultValueAttribute ).Value?.ToString() : null ),
                        IsRequired = x.GetCustomAttributes()
                                      .Where(f =>
                                              f.TypeId.ToString().IndexOf("RequiredAttribute") >= 0
                                            ).Any() ||
                                            ( ( x.PropertyType == typeof(int) && !x.GetCustomAttributes().Where(k => k.TypeId.ToString().IndexOf("KeyAttribute") > 0).Any() ) ||
                                             x.PropertyType == typeof(DateTime) ||
                                             x.PropertyType == typeof(decimal)
                                             ),
                         IgnoredColumn= x.GetCustomAttributes().Where(k => k.TypeId.ToString().IndexOf("KeyAttribute") > 0).Any()

                      })
             .OrderBy(x => x.EntitySetName)
             .Where(x => x.FieldTypeName != "ICollection`1").ToList();

      var entityType = asm.GetTypes()
             .Where(type => typeof(Entity).IsAssignableFrom(type)).Where(x => x.Name == entityName).First();

      //this.Queryable().Where(x => x.EntitySetName == entityName).Delete();
      foreach (var item in list)
      {
        if (!this.Queryable().Where(x => x.EntitySetName == entityName && x.FieldName==item.FieldName).Any())
        {
          var row = new DataTableImportMapping
          {
            EntitySetName = item.EntitySetName,
            FieldName = item.FieldName,
            IsRequired = item.IsRequired,
            TypeName = item.FieldTypeName,
            DefaultValue = item.DefaultValue,
            IsEnabled = item.IsRequired,
            IgnoredColumn = item.IgnoredColumn,
            SourceFieldName = AttributeHelper.GetDisplayName(entityType, item.FieldName)
          };
          this.Insert(row);
        }

      }
    }


    public DataTableImportMapping FindMapping(string entitySetName, string sourceFieldName) => this.Queryable().Where(x => x.EntitySetName == entitySetName && x.SourceFieldName == sourceFieldName).FirstOrDefault();

    public void CreateExcelTemplate(string entityname, string filename)
    {
      var mapping = this.Queryable().Where(x => x.EntitySetName == entityname && x.IsEnabled == true).ToList();
      FileInfo finame = new FileInfo(filename);
      if (File.Exists(filename))
      {
        File.Delete(filename);
      }
      using (ExcelPackage excel = new ExcelPackage(finame))
      {
        var sheet = excel.Workbook.Worksheets.Add(entityname);
        int col = 0;
        foreach (var row in mapping)
        {
          col++;
          sheet.Cells[1, col].Value = row.SourceFieldName;
          sheet.Cells[1, col].Style.Font.Bold = true;
          sheet.Cells[1, col].Style.Border.Top.Style = ExcelBorderStyle.Thin;
          sheet.Cells[1, col].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
          sheet.Cells[1, col].Style.Border.Left.Style = ExcelBorderStyle.Thin;
          sheet.Cells[1, col].Style.Border.Right.Style = ExcelBorderStyle.Thin;

          sheet.Cells[1, col].Style.Border.Top.Color.SetColor(System.Drawing.Color.Black);
          sheet.Cells[1, col].Style.Border.Bottom.Color.SetColor(System.Drawing.Color.Black);
          sheet.Cells[1, col].Style.Border.Left.Color.SetColor(System.Drawing.Color.Black);
          sheet.Cells[1, col].Style.Border.Right.Color.SetColor(System.Drawing.Color.Black);
          sheet.Cells[1, col].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
          sheet.Cells[1, col].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
          if (row.TypeName == "DateTime")
            sheet.Cells[1, col].Style.Numberformat.Format = "mm-dd-yyyy";
        }
        excel.Save();
      }
    }

  }
}



