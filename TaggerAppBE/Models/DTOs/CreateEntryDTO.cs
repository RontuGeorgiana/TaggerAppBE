using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaggerAppBE.Models.DTOs
{
    public class CreateEntryDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stars { get; set; }
        public int Reviews { get; set; }

        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }

        public IEnumerable<string> Tags { get; set; }
    }
}
