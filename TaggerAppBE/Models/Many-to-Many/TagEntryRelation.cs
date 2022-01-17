using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaggerAppBE.Models.Many_to_Many
{
    public class TagEntryRelation
    {
        public Guid TagId { get; set; }
        public Tag Tag { get; set; }
        public Guid EntryId { get; set; }
        public Entry Entry { get; set; }
    }
}
