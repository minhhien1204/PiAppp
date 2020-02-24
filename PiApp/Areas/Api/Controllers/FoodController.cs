using Microsoft.AspNet.OData;
using PiApp.Core.Models;
using PiApp.Core.Repositories;
using PiApp.Core.UnitOfWork;
using PiApp.Data;
using PiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using static PiApp.Services.FoodService;

namespace PiApp.Areas.Api.Controllers
{
    public class FoodController : ODataController
    {
        private readonly IUnitOfWorkAsync _unitOfWork;
        private readonly IFoodService _foodservice;

        public FoodController(IUnitOfWorkAsync unitOfWork,IFoodService foodService)
        {
            _unitOfWork = unitOfWork;
            _foodservice = foodService;
        }

        [EnableQuery]
        public IQueryable<FoodViewModel> Get()   //neu la Food thi se k Update dc..
        {
            return _foodservice.GetAllFoods();
        }
        public IHttpActionResult Put(int key,FoodViewModel updatedfood) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _foodservice.Update(key, updatedfood);
            _unitOfWork.SaveChange();
            return Updated(updatedfood);
        }
        public IHttpActionResult Post(FoodViewModel newfood)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _foodservice.InsertFood(newfood);
            _unitOfWork.SaveChange();
            return Created(newfood);
        }

        public IHttpActionResult Delete(int key) //neu k phai tu key..se~ k Call function
        {
            _foodservice.Delete(key);
            _unitOfWork.SaveChange();
            return Ok();
        }
   
        
    }
}