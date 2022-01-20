using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaggerAppBE.Models;
using TaggerAppBE.Models.DTOs;
using TaggerAppBE.Models.One_to_Many;

namespace TaggerAppBE.Services
{
    public interface IUserService
    {
        UserResponseDTO Authenticate(UserRequestDTO req);
        UserResponseDTO Create(UserRequestDTO user, string role);
        List<UserResponseDTO> GetAllUsers();
        User GetById(Guid id);
    }
}
