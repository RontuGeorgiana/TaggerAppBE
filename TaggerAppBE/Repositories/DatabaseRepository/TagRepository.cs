using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaggerAppBE.Data;
using TaggerAppBE.Models.Many_to_Many;
using TaggerAppBE.Repositories.GenericRepository;

namespace TaggerAppBE.Repositories.DatabaseRepository
{
    public class TagRepository : GenericRepository<Tag>, ITagRepository
    {
        public TagRepository(TaggerContext context) : base(context)
        {

        }

        public List<Tag> GetAll()
        {
            return _table.ToList();
        }

        public Tag GetByName(string name)
        {
            return _table.FirstOrDefault(t => t.Name.Equals(name));
        }

        public Tag GetById(Guid Id)
        {
            return _table.FirstOrDefault(c => c.Id.Equals(Id));
        }

        public void Update(Tag tag)
        {
            _table.Update(tag);
        }

        public void Add(Tag tag)
        {
            _table.Add(tag);
        }

        public void AddBulk(IEnumerable<Tag> tags)
        {
            _table.AddRange(tags);
        }
    }
}
