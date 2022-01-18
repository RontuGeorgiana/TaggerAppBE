using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaggerAppBE.Models.DTOs;
using TaggerAppBE.Models.Many_to_Many;

namespace TaggerAppBE.Services
{
    public interface ITagService
    {
        TagDTO GetTagById(Guid Id);
        TagDTO GetTagByName(string name);
        TagDTO UpdatePostsById(Guid Id, int posts);
        TagDTO Add(CreateTagDTO tag);
        bool AddBulk(IEnumerable<CreateTagDTO> tags);
        List<TagDTO> GetAllTags();
    }
}
