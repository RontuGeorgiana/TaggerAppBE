using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaggerAppBE.Models.Many_to_Many;
using TaggerAppBE.Repositories.GenericRepository;

namespace TaggerAppBE.Repositories.DatabaseRepository
{
    public interface IEntryRepository: IGenericRepository<Entry>
    {
        List<Entry> GetAllByCategory(Guid categoyId);
        Entry GetEntryById(Guid Id);
        void Update(Entry entry);
        void Add(Entry entry);
    }
}
