using System;
using System.Threading.Tasks;
using trackapi.DTO;
using trackapi.Model;
using trackapi.Repositories.Interfaces;

namespace trackapi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoRepository<User> MongoUserRepository;

        public UserRepository(IMongoRepository<User> MongoUserRepository)
            => this.MongoUserRepository = MongoUserRepository;
        public async Task<UserDTO> Create(User user)
        {
            var _user = MongoUserRepository.FindOne(
                filter => filter.Email == user.Email
            );

            if(_user != null )
                throw new Exception();
            
            await MongoUserRepository.InsertOneAsync(user);
            return new UserDTO(){
                Name = user.Name,
                Email = user.Email,
                TrackersIds = user.TrackersIds
            };
        }
    
        public UserDTO GetByEmail (string email)
        {
            User user = MongoUserRepository.FindOne(
                filter => filter.Email == email
            );

            if(user != null)
                return new UserDTO(){
                    Name = user.Name,
                    Email = user.Email,
                    TrackersIds = user.TrackersIds ?? null
                };
            return null;
        }
    }
}