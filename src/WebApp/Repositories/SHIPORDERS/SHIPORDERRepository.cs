using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Repository.Pattern.Repositories;
using WebApp.Models;
namespace WebApp.Repositories
{
/// <summary>
/// File: SHIPORDERRepository.cs
/// Purpose: The repository and unit of work patterns are intended
/// to create an abstraction layer between the data access layer and
/// the business logic layer of an application.
/// Created Date: 8/12/2019 9:08:06 AM
/// Author: neo.zhu
/// Tools: SmartCode MVC5 Scaffolder for Visual Studio 2017
/// Copyright (c) 2012-2018 All Rights Reserved
/// </summary>
  public static class SHIPORDERRepository  
    {
                        public static IEnumerable<SHIPORDERDETAIL>   GetSHIPORDERDETAILSBySHIPORDERID (this IRepositoryAsync<SHIPORDER> repository,int shiporderid)
        {
			var shiporderdetailRepository = repository.GetRepository<SHIPORDERDETAIL>(); 
            return shiporderdetailRepository.Queryable().Include(x => x.SHIPORDER).Where(n => n.SHIPORDERID == shiporderid);
        }
         
	}
}



