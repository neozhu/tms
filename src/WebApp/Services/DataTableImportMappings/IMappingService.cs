﻿
     
 
 
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Repository.Pattern.Repositories;
using Service.Pattern;
using WebApp.Models;
using WebApp.Repositories;

namespace WebApp.Services
{
    public interface IDataTableImportMappingService:IService<DataTableImportMapping>
    {

        IEnumerable<EntityInfo> GetAssemblyEntities();
        void GenerateByEnityName(string entityName);

        DataTableImportMapping FindMapping(string entitySetName, string sourceFieldName);
        void CreateExcelTemplate(string entityname, string filename);
    }
}