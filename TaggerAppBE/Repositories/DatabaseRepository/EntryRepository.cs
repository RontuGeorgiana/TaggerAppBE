using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaggerAppBE.Data;
using TaggerAppBE.Models.DTOs;
using TaggerAppBE.Models.Many_to_Many;
using TaggerAppBE.Repositories.GenericRepository;

namespace TaggerAppBE.Repositories.DatabaseRepository
{
    public class EntryRepository : GenericRepository<Entry>, IEntryRepository
    {
        public EntryRepository(TaggerContext context) : base(context)
        {

        }

        public List<Entry> GetAllByCategory(Guid categoyId)
        {
            return _table.AsNoTracking().Include(e=>e.TagEntryRelations).Where(e => e.CategoryId.Equals(categoyId)).Distinct().ToList();
        }
        public Entry GetEntryById(Guid Id)
        {
            return _table.Include(e => e.TagEntryRelations).FirstOrDefault(c => c.Id.Equals(Id));
        }
        public void Update(Entry entry)
        {
            _table.Update(entry);
        }

        public void Add(Entry entry)
        {
            _table.Add(entry);
        }
    }
}
