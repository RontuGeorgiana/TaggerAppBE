using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaggerAppBE.Models.DTOs;
using TaggerAppBE.Models.Many_to_Many;
using TaggerAppBE.Repositories.DatabaseRepository;

namespace TaggerAppBE.Services
{
    public class TagService: ITagService
    {
        public ITagRepository _tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public TagDTO GetTagById(Guid Id)
        {
            Tag tag = _tagRepository.GetById(Id);
            TagDTO result = new TagDTO()
            {
                Id= tag.Id,
                Name= tag.Name,
                Posts= tag.Posts
            };
            return result;
        }

        public TagDTO GetTagByName(string name)
        {
            Tag tag = _tagRepository.GetByName(name);
            TagDTO result = new TagDTO()
            {
                Id = tag.Id,
                Name = tag.Name,
                Posts = tag.Posts
            };
            return result;
        }

        public TagDTO UpdatePostsById(Guid Id, int posts)
        {
            Tag tag = _tagRepository.GetById(Id);
            tag.Posts = posts;
            _tagRepository.Update(tag);
            _tagRepository.Save();
            TagDTO result = new TagDTO()
            {
                Id = tag.Id,
                Name = tag.Name,
                Posts = tag.Posts
            };
            return result;
        }

        public TagDTO Add(CreateTagDTO tag)
        {
            Tag tagToAdd = new Tag()
            {
                Name = tag.Name,
                Posts = 1
            };
            _tagRepository.Add(tagToAdd);
            _tagRepository.Save();
            Tag addedTag =  _tagRepository.GetById(tagToAdd.Id);
            TagDTO result = new TagDTO()
            {
                Id = addedTag.Id,
                Name = addedTag.Name,
                Posts = addedTag.Posts
            };
            return result;
        }

        public bool AddBulk(IEnumerable<CreateTagDTO> tags)
        {
            List<Tag> tagsToAdd = new List<Tag>();
            foreach (CreateTagDTO tag in tags)
            {
                Tag tagToAdd = new Tag()
                {
                    Name = tag.Name,
                    Posts = 1
                };
                tagsToAdd.Add(tagToAdd);
            }
            _tagRepository.AddBulk(tagsToAdd);
            return( _tagRepository.Save());
        }

        public List<TagDTO> GetAllTags()
        {
            List<Tag> tags = _tagRepository.GetAll();

            List<TagDTO> results = new List<TagDTO>();

            foreach (Tag tag in tags)
            {
                TagDTO result = new TagDTO()
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    Posts = tag.Posts
                };
                results.Add(result);
            }

            return results;
        }
    }
}
