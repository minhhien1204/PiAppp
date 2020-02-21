using Microsoft.AspNet.OData;
using PiApp.Core.Models;
using PiApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PiApp.Areas.Api.Controllers
{
    public class CategoryController : ODataController
    {
        private readonly DataContext _dbcontext = new DataContext(); //
        [EnableQuery]
        public IQueryable<Category> Get()
        {
            return _dbcontext.Categories;
        }
    }
}