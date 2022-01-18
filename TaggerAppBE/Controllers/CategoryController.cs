using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaggerAppBE.Data;
using TaggerAppBE.Services;

namespace TaggerAppBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("/categories")]
        public async Task<IActionResult> GetAllCategories()
        {
            return Ok(_categoryService.GetAllCategories());
        }

        [HttpGet("/categories-batch")]
        public async Task<IActionResult> GetCategoriesBatchById([FromQuery(Name = "Ids")]IEnumerable<Guid> Ids)
        {
            return Ok(_categoryService.GetCategoryBatchById(Ids));
        }

        [HttpGet("/categories/{Id}")]
        public async Task<IActionResult> GetCategoryById([FromRoute]Guid Id)
        {
            return Ok(_categoryService.GetCategoryById(Id));
        }

        [HttpPatch("/categories/{Id}")]
        public async Task<IActionResult> PatchCategoryById([FromRoute]Guid Id, [FromQuery(Name = "posts")]int posts)
        {
           return Ok(_categoryService.UpdatePostsNumberById(Id, posts));
        }
    }
}
