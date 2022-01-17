using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaggerAppBE.Models.Base;

namespace TaggerAppBE.Models.Many_to_Many
{
    public class Tag: BaseEntity
    {
        public string Name { get; set; }
        public int Posts { get; set; }

        public ICollection<TagEntryRelation> TagEntryRelations { get; set; }
    }
}
