using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaggerAppBE.Models.DTOs
{
    public class CategoryDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Posts { get; set; }
    }
}
