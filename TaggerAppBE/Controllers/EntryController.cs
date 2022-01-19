using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaggerAppBE.Models.DTOs;
using TaggerAppBE.Services;

namespace TaggerAppBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntryController : ControllerBase
    {
        private readonly IEntryService _entryService;
        private readonly ITagService _tagService;

        public EntryController(IEntryService entryService, ITagService tagService)
        {
            _entryService = entryService;
            _tagService = tagService;
        }

        [HttpGet("/entries")]
        public async Task<IActionResult> GetAllInCategory([FromQuery(Name ="Category Id")] Guid Id)
        {
            //var entries = _entryService.GetAllEntriesByCategory(Id);
            //Console.Write(entries);
            return Ok(_entryService.GetAllEntriesByCategory(Id));
         }

        [HttpGet("/entries/{Id}")]
        public async Task<IActionResult> GetEntryById([FromRoute] Guid Id)
        {
            return Ok(_entryService.GetEntryById(Id));
        }

        [HttpPost("/entries")]
        public async Task<IActionResult> CreateEntry([FromBody]CreateEntryDTO entry)
        {
            _entryService.Add(entry);

            return Ok();
        }

        [HttpPatch("/entries/{Id}")]
        public async Task<IActionResult> UpdateEntry([FromBody] UpdateEntryDTO entry, [FromRoute]Guid Id)
        {
            _entryService.Update(entry, Id);

            return Ok();
        }
    }

}

