using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaggerAppBE.Models.Base;
using TaggerAppBE.Models.Many_to_Many;

namespace TaggerAppBE.Models.One_to_Many
{
    public class Category: BaseEntity
    {
        public string Name { get; set; }
        public int Posts { get; set; }

        public ICollection<Entry> Entries { get; set; }
        public ICollection<LikedCategory> LikedCategories { get; set; }
    }
}
