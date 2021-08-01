using System.Collections.Generic;
using System.Threading.Tasks;
using trackapi.DTO;
using trackapi.Model;

namespace trackapi.Repositories.Interfaces
{
    public interface ITrackerRepository
    {
        Task<IEnumerable<TrackerDTO>> GetAll();
        Task<TrackerDTO> GetById (string id);
        Task<TrackerDTO> Create (Tracker Tracker);
        Task<TrackerDTO> Update (TrackerDTO TrackerDTO);
        Task<bool> Delete (string id);
 
    }
}