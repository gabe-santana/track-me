using System.Collections.Generic;
using System.Threading.Tasks;
using trackapi.DTO;
using trackapi.Model;

namespace trackapi.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDTO> GetByEmail (string email);
        Task<UserDTO> Create (User user);
 
    }
}