using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaggerAppBE.Models.DTOs;
using TaggerAppBE.Models.Many_to_Many;

namespace TaggerAppBE.Services
{
    public interface IEntryService
    {
        List<EntryDTO> GetAllEntriesByCategory(Guid categoyId);
        EntryDTO GetEntryById(Guid Id);
        void Update(UpdateEntryDTO entry, Guid entryId);
        void Add(CreateEntryDTO entry);
    }
}
