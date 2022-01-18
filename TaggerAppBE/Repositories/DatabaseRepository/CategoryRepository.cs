using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaggerAppBE.Data;
using TaggerAppBE.Models.One_to_Many;
using TaggerAppBE.Repositories.GenericRepository;

namespace TaggerAppBE.Repositories.DatabaseRepository
{
    public class CategoryRepository: GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(TaggerContext context): base(context)
        {

        }

        public List<Category> GetAll()
        {
            return _table.ToList();
        }

        public List<Category> GetBatchById(IEnumerable<Guid> Ids)
        {
            return _table.Where(c => Ids.Contains(c.Id)).ToList();
        }

        public Category GetById(Guid Id)
        {
            return _table.FirstOrDefault(c => c.Id.Equals(Id));
        }

        public void Update(Category category)
        {
            _table.Update(category);
        }
    }
}
