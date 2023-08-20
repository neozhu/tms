using System.Collections.Generic;
using System.Linq;
using Repository.Pattern.Repositories;
using Service.Pattern;

using WebApp.Models;
using WebApp.Repositories;
namespace WebApp.Services
{
  public class RoleMenuService : Service<RoleMenu>, IRoleMenuService
  {

    private readonly IRepositoryAsync<RoleMenu> _repository;
    private readonly IRepositoryAsync<MenuItem> _menurepository;
    public RoleMenuService(IRepositoryAsync<RoleMenu> repository, IRepositoryAsync<MenuItem> menurepository)
        : base(repository)
    {
      this._repository = repository;
      this._menurepository = menurepository;
    }

    public IEnumerable<RoleMenu> GetByMenuId(int menuid) => this._repository.GetByMenuId(menuid);




    public IEnumerable<RoleMenu> GetByRoleName(string roleName) => this._repository.Queryable().Where(x => x.RoleName == roleName);


    public void Authorize(RoleMenusView[] list)
    {
      var rolename = list.First().RoleName;
      var menuid = list.First().MenuId;
      var mymenus = this.GetByRoleName(rolename);
      foreach (var item in mymenus)
      {
        this.Delete(item);
      }

      if (menuid > 0)
      {
        foreach (var item in list)
        {
          var rm = new RoleMenu
          {
            MenuId = item.MenuId,
            RoleName = item.RoleName,
            Create = item.Create,
            Delete = item.Delete,
            Edit = item.Edit,
            Import = item.Import,
            Export = item.Export,
            FunctionPoint1 = item.FunctionPoint1,
            FunctionPoint2 = item.FunctionPoint2,
            FunctionPoint3 = item.FunctionPoint3
          };
          this.Insert(rm);
        }
      }




    }

    private void FindParentMenus(List<MenuItem> list, MenuItem item)
    {
      if (item.ParentId != null && item.ParentId > 0)
      {
        var pitem = this._menurepository.Find(item.ParentId);
        if (!list.Where(x => x.Id == pitem.Id).Any())
        {
          list.Add(pitem);
        }
        if (pitem.ParentId != null && pitem.ParentId > 0)
        {
          this.FindParentMenus(list, pitem);
        }
      }
    }

    public IEnumerable<MenuItem> RenderMenus(string[] roleNames)
    {
      var allmenus = this._menurepository.Queryable().OrderBy(n => n.Code).ToList();
      var mymenus = this._repository.Queryable().Where(x => roleNames.Contains(x.RoleName));
      var menulist = new List<MenuItem>();
      foreach (var item in allmenus)
      {
        var myitem = mymenus.Where(x => x.MenuId == item.Id).Any();
        if (myitem)
        {
          if (!menulist.Where(x => x.Id == item.Id).Any())
          {
            menulist.Add(item);
          }
          if (item.ParentId != null && item.ParentId > 0)
          {
            this.FindParentMenus(menulist, item);
          }
        }
      }
      return menulist;
    }
  }
}



