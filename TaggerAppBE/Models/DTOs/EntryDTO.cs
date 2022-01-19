using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaggerAppBE.Models.DTOs
{
    public class EntryDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stars { get; set; }
        public int Reviews { get; set; }
        public List<string> Tags { get; set; }
    }
}
