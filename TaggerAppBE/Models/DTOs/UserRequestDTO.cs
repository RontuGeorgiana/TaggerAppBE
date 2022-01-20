using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaggerAppBE.Models.DTOs
{
    public class UserRequestDTO
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
