using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaggerAppBE.Models.One_to_Many;
using TaggerAppBE.Repositories.GenericRepository;

namespace TaggerAppBE.Repositories.DatabaseRepository
{
    public interface ICategoryRepository: IGenericRepository<Category>
    {
        Category GetById(Guid Id);
        List<Category> GetBatchById(IEnumerable<Guid> Ids);
        void Update(Category category);
        List<Category> GetAll();

    }
}
