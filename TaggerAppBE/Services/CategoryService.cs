using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaggerAppBE.Models.DTOs;
using TaggerAppBE.Models.One_to_Many;
using TaggerAppBE.Repositories.DatabaseRepository;

namespace TaggerAppBE.Services
{
    public class CategoryService: ICategoryService
    {
        public ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public CategoryDTO GetCategoryById(Guid Id)
        {
            Category category = _categoryRepository.GetById(Id);

            CategoryDTO result = new CategoryDTO()
            {
                Id = category.Id,
                Name = category.Name,
                Posts = category.Posts
            };

            return result;

        }

        public List<CategoryDTO> GetAllCategories()
        {
            List<Category> categories = _categoryRepository.GetAll();

            List<CategoryDTO> results = new List<CategoryDTO>();

            foreach (Category category in categories)
            {
                CategoryDTO result = new CategoryDTO()
                {
                    Id = category.Id,
                    Name = category.Name,
                    Posts = category.Posts
                };
                results.Add(result);
            }

            return results;
        }

        public List<CategoryDTO> GetCategoryBatchById(IEnumerable<Guid> Ids)
        {
            List<Category> categories = _categoryRepository.GetBatchById(Ids);

            List<CategoryDTO> results = new List<CategoryDTO>();

            foreach (Category category in categories)
            {
                CategoryDTO result = new CategoryDTO()
                {
                    Id = category.Id,
                    Name = category.Name,
                    Posts = category.Posts
                };
                results.Add(result);
            }

            return results;
        }

        public CategoryDTO UpdatePostsNumberById(Guid Id, int posts)
        {
            Category category = _categoryRepository.GetById(Id);
            category.Posts = posts;
            _categoryRepository.Update(category);
            _categoryRepository.Save();
            CategoryDTO result = new CategoryDTO()
            {
                Id = category.Id,
                Name = category.Name,
                Posts = category.Posts
            };
            return result;
        }
    }
}
