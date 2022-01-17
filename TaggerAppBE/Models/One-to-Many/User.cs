using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaggerAppBE.Models.Base;
using TaggerAppBE.Models.Many_to_Many;
using TaggerAppBE.Models.One_to_One;

namespace TaggerAppBE.Models.One_to_Many
{
    public class User: BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string role { get; set; }

        public Profile Profile { get; set; }
        public ICollection<Entry> Entries { get; set; }
    }
}
