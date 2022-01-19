using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaggerAppBE.Data;
using TaggerAppBE.Models.DTOs;
using TaggerAppBE.Models.Many_to_Many;
using TaggerAppBE.Repositories.DatabaseRepository;

namespace TaggerAppBE.Services
{
    public class EntryService:IEntryService
    {
        public IEntryRepository _entryRepository;
        public ITagRepository _tagRepository;

        public EntryService(IEntryRepository entryRepository, ITagRepository tagRepository)
        {
            _entryRepository = entryRepository;
            _tagRepository = tagRepository;
        }

 
        public void Add(CreateEntryDTO entry)
        {
            Entry entryToAdd = new Entry() 
            {
                Name= entry.Name,
                Description= entry.Description, 
                Stars=entry.Stars,
                Reviews=entry.Reviews,
                CategoryId=entry.CategoryId,
                UserId=entry.UserId,
                
            };

            List<TagEntryRelation> relations = new List<TagEntryRelation>();
            foreach(string tagName in entry.Tags)
            {
                Tag tag = _tagRepository.GetByName(tagName);
                TagEntryRelation relation = new TagEntryRelation()
                {
                    Entry = entryToAdd,
                    EntryId = entryToAdd.Id,
                    Tag = tag,
                    TagId = tag.Id
                };
                relations.Add(relation);
            }

            entryToAdd.TagEntryRelations = relations;

            _entryRepository.Add(entryToAdd);
            _entryRepository.Save();

        }

        public void Update(UpdateEntryDTO entry, Guid entryId)
        {
            Entry entryToUpdate = _entryRepository.GetEntryById(entryId);
            
            if (!(bool)entry?.Description?.Equals(""))
            {
                entryToUpdate.Description = entry.Description;
            }
            if (!(bool)entry?.Stars.Equals(null))
            {
                entryToUpdate.Stars = entry.Stars;
            }
            if (!(bool)entry?.Reviews.Equals(null))
            {
                entryToUpdate.Reviews = entry.Reviews;
            }
            if(!(bool)entry?.Tags?.Equals(null))
            {
                List<TagEntryRelation> relations = new List<TagEntryRelation>();
                foreach (string tagName in entry.Tags)
                {
                     Tag tag = _tagRepository.GetByName(tagName);
                     TagEntryRelation relation = new TagEntryRelation()
                     {
                        Entry = entryToUpdate,
                        EntryId = entryToUpdate.Id,
                        Tag = tag,
                        TagId = tag.Id
                     };
                    entryToUpdate.TagEntryRelations.Add(relation);
                }
            }
            
            _entryRepository.Update(entryToUpdate);
            _entryRepository.Save();
        }

        public List<EntryDTO> GetAllEntriesByCategory(Guid categoyId)
        {
            var entries =  _entryRepository.GetAllByCategory(categoyId);
            List<EntryDTO> results = new List<EntryDTO>();
            foreach (var entry in entries)
            {   List<string> tags = new List<string>();
                if(entry.TagEntryRelations.Count() > 0)
                {
                   
                    foreach (TagEntryRelation relation in entry.TagEntryRelations)
                    {
                        Tag tag = _tagRepository.GetById(relation.TagId);
                        tags.Add(tag.Name);
                    }
                    EntryDTO result = new EntryDTO()
                    {
                        Id = entry.Id,
                        Name = entry.Name,
                        Description = entry.Description,
                        Stars = entry.Stars,
                        Reviews = entry.Reviews,
                        Tags = tags
                    };
                    
                    results.Add(result);
                }
                
            }
                return results;

        }

        public EntryDTO GetEntryById(Guid Id)
        {
            Entry entry = _entryRepository.GetEntryById(Id);
            List<string> tags = new List<string>();
            if (entry.TagEntryRelations.Count() > 0)
            {

                foreach (TagEntryRelation relation in entry.TagEntryRelations)
                {
                    Tag tag = _tagRepository.GetById(relation.TagId);
                    tags.Add(tag.Name);
                }

            }
            EntryDTO result = new EntryDTO()
            {
                Id = entry.Id,
                Name = entry.Name,
                Description = entry.Description,
                Stars = entry.Stars,
                Reviews = entry.Reviews,
                Tags = tags
            };

            return result;
        }
    }
}
