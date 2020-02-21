using Microsoft.AspNet.OData;
using PiApp.Core.Models;
using PiApp.Core.Repositories;
using PiApp.Core.UnitOfWork;
using PiApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace PiApp.Areas.Api.Controllers
{
    public class FoodController : ODataController
    {
        private readonly IUnitOfWorkAsync unitOfWork;
        public FoodController()
        {
            unitOfWork = new UnitOfWork(new DataContext());
        }

        [EnableQuery]
        public IQueryable<Food> Get()
        {
            return unitOfWork.RepositoryAsync<Food>().Queryable();
            
        }



        //private readonly DataContext _dbcontext = new DataContext(); //
        //[EnableQuery]
        //public IQueryable<Food> Get()
        //{
        //    return _dbcontext.Foods;
        //}
        ////add food
        //public IHttpActionResult Post(Food food)
        //{
        //    var data = new Food
        //    {
        //        Name = food.Name,
        //        Price = food.Price,
        //        PricePromotion = food.PricePromotion,
        //        CategoryId = food.CategoryId,
        //        CreateDate = DateTime.Now
        //    };
        //    _dbcontext.Foods.Add(data);
        //    _dbcontext.SaveChanges();
        //    return Created(food);
        //}

        ////get 1 food
        //public SingleResult<Food> Get([FromODataUri] int key)
        //{
        //    var result = _dbcontext.Foods.Where(x => x.Id == key);
        //    return SingleResult.Create(result);
        //}
    }
}