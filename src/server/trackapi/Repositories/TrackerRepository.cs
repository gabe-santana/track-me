using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using trackapi.DTO;
using trackapi.Mappers;
using trackapi.Model;
using trackapi.Repositories.Interfaces;

namespace trackapi.Repositories
{
    public class TrackerRepository : ITrackerRepository
    {
        private readonly IMongoRepository<Tracker> MongoTrackerRepository;
        private readonly TrackerMapper trackerMapper = new TrackerMapper();

        public TrackerRepository(IMongoRepository<Tracker> MongoTrackerRepository)
            => this.MongoTrackerRepository = MongoTrackerRepository;
    
        public async Task<TrackerDTO> GetById(string id)
        {
            Tracker tracker = await MongoTrackerRepository.FindById(new ObjectId(id));
            if(tracker != null)
                return trackerMapper.ToDTO(tracker);
            return null;
        }
        public async Task<IEnumerable<TrackerDTO>> GetAll()
        {
            var query = await MongoTrackerRepository.Find();
            return trackerMapper.ToDTOList(query);
        }
    
        public async Task<TrackerDTO> Create(Tracker Tracker)
        {
            await MongoTrackerRepository.InsertOneAsync(Tracker);
            return trackerMapper.ToDTO(Tracker);
        }

        public async Task<TrackerDTO> Update (Tracker Tracker)
        {
            Tracker.UpdatedAt = DateTime.Now;
            var updatedTracker = await MongoTrackerRepository.ReplaceOneAsync(Tracker);
            return trackerMapper.ToDTO(Tracker);
        }
   
        public async Task<bool> Delete (string id)
        {
            try{
                await MongoTrackerRepository.DeleteById(id);
                return true;
            }
            catch{
                return false;
            }
           
        }
    }
}