using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaggerAppBE.Models.DTOs;
using TaggerAppBE.Models.Many_to_Many;
using TaggerAppBE.Services;

namespace TaggerAppBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet("/tags")]
        public async Task<IActionResult> GetAllTags()
        {
            return Ok(_tagService.GetAllTags());
        }

        [HttpGet("/tags/{Id}")]
        public async Task<IActionResult> GetTagById([FromRoute] Guid Id)
        {
            return Ok(_tagService.GetTagById(Id));
        }

        [HttpGet("/tags/{name}")]
        public async Task<IActionResult> GetTagByName([FromRoute] string name)
        {
            return Ok(_tagService.GetTagByName(name));
        }

        [HttpPatch("/tags/{Id}")]
        public async Task<IActionResult> PatchTagById([FromRoute] Guid Id, [FromQuery(Name = "posts")] int posts)
        {
            return Ok(_tagService.UpdatePostsById(Id, posts));
        }

        [HttpPost("/tags")]
        public async Task<IActionResult> CreateTag([FromBody]CreateTagDTO tag)
        {
            return Ok(_tagService.Add(tag));
        }

        [HttpPost("/tags-bulk")]
        public async Task<IActionResult> CreateTagsBulk([FromBody] IEnumerable<CreateTagDTO> tags)
        {
            return Ok(_tagService.AddBulk(tags));
        }
    }
}
