using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaggerAppBE.Models.DTOs;
using TaggerAppBE.Models.One_to_Many;

namespace TaggerAppBE.Services
{
    public interface ICategoryService
    {
        CategoryDTO GetCategoryById(Guid Id);
        List<CategoryDTO> GetAllCategories();
        List<CategoryDTO> GetCategoryBatchById(IEnumerable<Guid> Ids);
        CategoryDTO UpdatePostsNumberById(Guid Id, int posts);

    }
}
