using PiApp.Core.Models;
using PiApp.Core.Repositories;
using PiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PiApp.Services.CategoryService;

namespace PiApp.Services
{
    public class CategoryService:Service<Category>,ICategoryService
    {
        public interface ICategoryService: IService<Category>
        {
            IQueryable<CategoryViewModel> GetCategories();
            void UpdateCategory(int key, CategoryViewModel model);
            void InsertCategory(CategoryViewModel model);
        }
        private IRepositoryAsync<Category> _repositoryAsync;
        public CategoryService(IRepositoryAsync<Category> repositoryAsync):base(repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public IQueryable<CategoryViewModel> GetCategories()
        {
            return _repositoryAsync.Queryable().Select(x => new CategoryViewModel() {
                Id= x.Id,
                Name = x.Name,
                CreateDate = x.CreateDate
            });
        }

        public void UpdateCategory(int key, CategoryViewModel model)
        {
            var category = Find(key);
            if(category != null)
            {
                category.Name = model.Name;
                category.CreateDate = DateTime.Now;
            }
        }
        public void InsertCategory(CategoryViewModel model)
        {
            var newdata = new Category()
            {
                Name = model.Name,
                CreateDate = DateTime.Now
            };
            base.Insert(newdata);
        }
    }
}
