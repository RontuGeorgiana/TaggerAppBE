using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaggerAppBE.Models.Many_to_Many;
using TaggerAppBE.Repositories.GenericRepository;

namespace TaggerAppBE.Repositories.DatabaseRepository
{
    public interface ITagRepository : IGenericRepository<Tag>
    {
        Tag GetById(Guid Id);
        Tag GetByName(string name);
        void Update(Tag tag);
        void Add(Tag tag);
        void AddBulk(IEnumerable<Tag> tags);
        List<Tag> GetAll();
    }
}
