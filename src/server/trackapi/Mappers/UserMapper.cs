using System.Collections.Generic;
using trackapi.DTO;
using trackapi.Mappers.Interfaces;
using trackapi.Model;

namespace trackapi.Mappers
{
    public class UserMapper : IEntityMapper<User, UserDTO>
    {
        public UserDTO ToDTO(User entity)
        {
            return new UserDTO{
                Name = entity.Name,
                Email = entity.Email,
                TrackerId = entity.TrackerId
            };
        }

        public User ToEntity(UserDTO entityDTO)
        {
            return new User{
                Name = entityDTO.Name,
                Email = entityDTO.Email,
                TrackerId = entityDTO.TrackerId
            };
        }
        public IEnumerable<UserDTO> ToDTOList(IEnumerable<User> entities)
        {
            foreach (var entity in entities)
            {
                yield return new UserDTO()
                {
                    Name = entity.Name,
                    Email = entity.Email,
                    TrackerId = entity.TrackerId
                };
            }
        }


        public IEnumerable<User> ToEntityList(IEnumerable<UserDTO> entityDTOs)
        {
            foreach (var entity in entityDTOs)
            {
                yield return new User()
                {
                    Name = entity.Name,
                    Email = entity.Email,
                    TrackerId = entity.TrackerId
                };
            }
        }
    }
}