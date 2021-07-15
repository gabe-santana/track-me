using System.Collections.Generic;
using System.Threading.Tasks;
using trackapi.DTO;
using trackapi.Model;

namespace trackapi.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDTO>> GetAll();
        Task<UserDTO> GetByEmail (string email);
        Task<UserDTO> Create (User user);
        Task<UserDTO> Update (User user);

        Task<bool> Delete (string email);
    }
}