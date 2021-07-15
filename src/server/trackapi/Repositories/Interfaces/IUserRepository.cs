using System.Threading.Tasks;
using trackapi.DTO;
using trackapi.Model;

namespace trackapi.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDTO> Create (User user);
        UserDTO GetByEmail (string email);
    }
}