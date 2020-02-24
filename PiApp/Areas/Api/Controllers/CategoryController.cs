using Microsoft.AspNet.OData;
using PiApp.Core.Models;
using PiApp.Core.UnitOfWork;
using PiApp.Data;
using PiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using static PiApp.Services.CategoryService;

namespace PiApp.Areas.Api.Controllers
{
    public class CategoryController : ODataController
    {
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly ICategoryService _categoryService;
        public CategoryController(IUnitOfWorkAsync unitOfWorkAsync,ICategoryService categoryService)
        {
            _unitOfWorkAsync = unitOfWorkAsync;
            _categoryService = categoryService;
        }
        [EnableQuery]
        public IQueryable<CategoryViewModel> Get()
        {
            return _categoryService.GetCategories();
        }
        public IHttpActionResult Put(int key, CategoryViewModel updatedcategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            };
            _categoryService.UpdateCategory(key, updatedcategory);
            _unitOfWorkAsync.SaveChange();
            return Updated(updatedcategory);
        }
        public IHttpActionResult Post(CategoryViewModel category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _categoryService.InsertCategory(category);
            _unitOfWorkAsync.SaveChange();
            return Created(category);
        }
    }
}