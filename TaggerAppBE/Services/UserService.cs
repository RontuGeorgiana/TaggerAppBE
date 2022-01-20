using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaggerAppBE.Data;
using TaggerAppBE.Models;
using TaggerAppBE.Models.DTOs;
using TaggerAppBE.Models.One_to_Many;
using TaggerAppBE.Utilities.JWTUtils;
using BC = BCrypt.Net.BCrypt;

namespace TaggerAppBE.Services
{
    public class UserService: IUserService
    {
        public TaggerContext _taggerContext;
        private IJWTUtils _iJWTUtils;

        public UserService(TaggerContext taggerContext, IJWTUtils iJWTUtils)
        {
            _taggerContext = taggerContext;
            _iJWTUtils = iJWTUtils;
        }

        public List<UserResponseDTO> GetAllUsers()
        {
            var users = _taggerContext.Users.ToList();
            var response = new List<UserResponseDTO>();
            foreach (User user in users)
            {
                response.Add(new UserResponseDTO(user, null));
            }
            return response;
        }

        public User GetById(Guid id)
        {
            return _taggerContext.Users.Find(id);
        }

        public UserResponseDTO Authenticate(UserRequestDTO req)
        {
            var user = _taggerContext.Users.FirstOrDefault(u => u.Username == req.Username);
            if (user==null || !BC.Verify(req.Password, user.PasswordHash))
            {
                return null;
            }

            var jwtToken = _iJWTUtils.GenerateJWTToken(user);
            return new UserResponseDTO(user, jwtToken);
        }

        public UserResponseDTO Create(UserRequestDTO user, string roleName)
        {
            Role role;
            if (roleName.ToLower() == "admin")
            {
                role = Role.Admin;
            }
            else
            {
                role = Role.User;
            }
            User userTOCreate = new User
            {
                Email = user.Email,
                Username = user.Username,
                PasswordHash = BC.HashPassword(user.Password),
                Role = role

            };

            _taggerContext.Users.Add(userTOCreate);
            _taggerContext.SaveChanges();
            return new UserResponseDTO(userTOCreate, null);
        }
    }
}
