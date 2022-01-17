using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaggerAppBE.Models.Base;
using TaggerAppBE.Models.One_to_One;

namespace TaggerAppBE.Models.One_to_Many
{
    public class LikedCategory: BaseEntity
    {
        public Guid CategoryId { get; set; }

        public Category Category { get; set; }

        public Profile Profile { get; set; }

        public Guid ProfileId { get; set; }
    }
}
