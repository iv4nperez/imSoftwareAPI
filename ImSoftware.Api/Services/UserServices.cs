using ImSoftware.Api.Database.Context;
using ImSoftware.Api.Database.Model;
using ImSoftware.Api.DTOs;
using ImSoftware.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ImSoftware.Api.Services
{
    public class UserServices : IUserServices
    {
        private readonly APIContext _context;
        public UserServices(APIContext context)
        {
                _context = context;
        }


        public async Task<List<UserDTO>> GetAllUsers()
        {
            var users = new List<UserDTO>();
            try
            {
                 users = await _context.Users.Where(x => x.RegDeleted == 0).Select(y => new UserDTO()
                {
                    UserId = y.IdUser,
                    UserAge = y.Age,
                    UserEmail = y.Email,
                    UserName = y.Name,
                }).ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }

            return users;
        }

        public async Task<UserDTO> PostCreateUser(UserParamDTO userParam)
        {
            var user = new UserDTO();
            try
            {
                var newUser = new User()
                {
                    Age = userParam.UserAge,
                    Email = userParam.UserEmail,
                    Name = userParam.UserName,
                    RegDeleted = 0
                };

                _context.Users.Add(newUser);
                _context.SaveChanges();

                // se usa un DTO para regresar la entidad y evitar riesgos de seguridad
                user = new UserDTO // una opcion mas eficiente es usar AutoMapper
                {
                    UserId = newUser.IdUser,
                    UserName = newUser.Name,
                    UserAge = newUser.Age,
                    UserEmail = newUser.Email,
                };
            }
            catch (Exception ex)
            {

                throw;
            }

            return user;
        }  

        public async Task<UserDTO> DeleteUser(long UserId)
        {

            var userDeleted = new UserDTO();
            try
            {
               var user = await _context.Users.Where(x=> x.IdUser == UserId).SingleOrDefaultAsync();
               user.RegDeleted = -1;
               
                _context.SaveChanges();

                // se usa un DTO para regresar la entidad y evitar riesgos de seguridad
                userDeleted = new UserDTO {
                    UserId = user.IdUser,
                    UserName = user.Name,
                    UserAge = user.Age,
                    UserEmail = user.Email,
                };
            }
            catch (Exception ex)
            {

                throw;
            }

            return userDeleted;
        }

    }
}
