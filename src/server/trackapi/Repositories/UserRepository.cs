using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Mappers;
using trackapi.DTO;
using trackapi.Mappers;
using trackapi.Model;
using trackapi.Repositories.Interfaces;

namespace trackapi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoRepository<User> MongoUserRepository;
        private readonly UserMapper userMapper = new UserMapper();

        public UserRepository(IMongoRepository<User> MongoUserRepository)
            => this.MongoUserRepository = MongoUserRepository;
    
        public async Task<UserDTO> GetByEmail (string email)
        {
            User user = await MongoUserRepository.FindOne(
                filter => filter.Email == email
            );
            if(user != null)
                return userMapper.ToDTO(user);
            return null;
        }
        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            var query = await MongoUserRepository.Find();
            return userMapper.ToDTOList(query);
        }
    
        public async Task<UserDTO> Create(User user)
        {
            var _user = await MongoUserRepository.FindOne(
                filter => filter.Email == user.Email
            );

            if(_user != null )
                throw new Exception();
            
            await MongoUserRepository.InsertOneAsync(user);
            return userMapper.ToDTO(user);
        }

        public async Task<UserDTO> Update (User user)
        {
            var _user = await MongoUserRepository.FindOne(
                filter => filter.Email == user.Email
            );

            if(_user == null )
                throw new Exception();

            user.UpdatedAt = DateTime.Now;
            user.Id = _user.Id;

            var updatedUser = await MongoUserRepository.ReplaceOneAsync(user);
            return userMapper.ToDTO(user);
        }
   
        public async Task<bool> Delete (string email)
        {
            try{
                await MongoUserRepository.DeleteOne(
                    filter => filter.Email == email
                );
                return true;
            }
            catch{
                return false;
            }
           
        }
    }
}