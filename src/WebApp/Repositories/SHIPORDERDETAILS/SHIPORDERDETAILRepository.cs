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
/// File: SHIPORDERDETAILRepository.cs
/// Purpose: The repository and unit of work patterns are intended
/// to create an abstraction layer between the data access layer and
/// the business logic layer of an application.
/// Created Date: 8/12/2019 8:47:21 AM
/// Author: neo.zhu
/// Tools: SmartCode MVC5 Scaffolder for Visual Studio 2017
/// Copyright (c) 2012-2018 All Rights Reserved
/// </summary>
  public static class SHIPORDERDETAILRepository  
    {
                 public static IEnumerable<SHIPORDERDETAIL> GetBySHIPORDERID(this IRepositoryAsync<SHIPORDERDETAIL> repository, int shiporderid)
         {
             var query= repository
                .Queryable()
                .Where(x => x.SHIPORDERID==shiporderid);
             return query;
         }  
                 
	}
}



