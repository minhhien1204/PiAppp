using PiApp.Core.Models;
using PiApp.Core.Repositories;
using PiApp.Data;
using PiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PiApp.Services.FoodService;

namespace PiApp.Services
{
    public class FoodService : Service<Food>, IFoodService
    {
        public interface IFoodService : IService<Food>
        {
            IQueryable<FoodViewModel> GetAllFoods();
            void InsertFood(FoodViewModel newfood);
            void Update(int key, FoodViewModel updatedfood);
        }
        private readonly IRepositoryAsync<Food> _repository;
        private readonly IRepositoryAsync<Category> _repositoryCategory;
        public FoodService(IRepositoryAsync<Food> repository,IRepositoryAsync<Category> repositoryCategory) : base(repository)
        {
            _repository = repository;
            _repositoryCategory = repositoryCategory;
        }

        private string GetNameOfCategoryById(int? key)
        {
            if (key == null)
                return "";
           
            return _repositoryCategory.Find(key).Name;
        }
        public IQueryable<FoodViewModel> GetAllFoods()
        {
            var list = Queryable().Select(x => new FoodViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                CategoryId = x.CategoryId,
                CreateDate = x.CreateDate,
                Price = x.Price,
                PricePromotion = x.PricePromotion,
            }).ToList();
            foreach (var item in list)
            {
                if (GetNameOfCategoryById(item.CategoryId) == "")
                    item.NameOfCategory = null;
                else
                    item.NameOfCategory = _repositoryCategory.Find(item.CategoryId).Name;
                 
            }
            return list.AsQueryable();

        }
        public void InsertFood(FoodViewModel newfood)
        {
            var food = new Food()
            {
                Id = newfood.Id,
                Name = newfood.Name,
                Price = newfood.Price,
                PricePromotion = newfood.PricePromotion,
                CreateDate = DateTime.Now,
                CategoryId = newfood.CategoryId
            };
            base.Insert(food);
        }
        public void Update(int key, FoodViewModel updatedfood)
        {
            var food = Find(key);
            if(food != null)
            {
                if(updatedfood.Name != null)
                    food.Name = updatedfood.Name;
                if (updatedfood.Price != 0)
                    food.Price = updatedfood.Price;
                if (updatedfood.PricePromotion != null)
                    food.PricePromotion = updatedfood.PricePromotion;
                food.CreateDate = DateTime.Now;
                if (updatedfood.CategoryId != null)
                    food.CategoryId = updatedfood.CategoryId;
            }
            
        }
    }
}
