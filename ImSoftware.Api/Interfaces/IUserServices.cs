using ImSoftware.Api.DTOs;

namespace ImSoftware.Api.Interfaces
{
    public interface IUserServices
    {
        Task<List<UserDTO>> GetAllUsers();
        Task<UserDTO> PostCreateUser(UserParamDTO userParam);
        Task<UserDTO> DeleteUser(long UserId);
    }
}
