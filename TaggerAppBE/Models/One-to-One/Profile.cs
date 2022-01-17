using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaggerAppBE.Models.Base;
using TaggerAppBE.Models.Many_to_Many;
using TaggerAppBE.Models.One_to_Many;

namespace TaggerAppBE.Models.One_to_One
{
    public class Profile: BaseEntity
    {
        public string Description { get; set; }

        public User User { get; set; }

        public Guid UserId { get; set; }

        public ICollection<LikedCategory> LikedCategories { get; set; }
    }
}
