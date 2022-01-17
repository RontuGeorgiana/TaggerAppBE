using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaggerAppBE.Models.Base;
using TaggerAppBE.Models.One_to_Many;

namespace TaggerAppBE.Models.Many_to_Many
{
    public class Entry: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stars { get; set; }
        public int Reviews { get; set; }

        public Category Category { get; set; }
        public User User { get; set; }

        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }

        public ICollection<TagEntryRelation> TagEntryRelations { get; set; }
    }
}
