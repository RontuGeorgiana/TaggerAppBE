using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaggerAppBE.Models.Base;
using TaggerAppBE.Models.Many_to_Many;

namespace TaggerAppBE.Models.One_to_Many
{
    public class User: BaseEntity
    {
        string username { get; set; }

        public ICollection<Entry> Entries { get; set; }
    }
}
