using System.Collections.Generic;
using trackapi.DTO;
using trackapi.Mappers.Interfaces;
using trackapi.Model;

namespace trackapi.Mappers
{
    public class TrackerMapper : IEntityMapper<Tracker, TrackerDTO>
    {
        public TrackerDTO ToDTO(Tracker entity)
        {
            return new TrackerDTO{
                Id = entity.Id,
                Location = entity.Location,
                State = entity.State
            };
        }

        public Tracker ToEntity(TrackerDTO entityDTO)
        {
            return new Tracker{
                Id = entityDTO.Id,
                Location = entityDTO.Location,
                State = entityDTO.State
            };
        }
        public IEnumerable<TrackerDTO> ToDTOList(IEnumerable<Tracker> entities)
        {
            foreach (var entity in entities)
            {
                yield return new TrackerDTO()
                {
                    Id = entity.Id,
                    Location = entity.Location,
                    State = entity.State
                };
            }
        }


        public IEnumerable<Tracker> ToEntityList(IEnumerable<TrackerDTO> entityDTOs)
        {
            foreach (var entity in entityDTOs)
            {
                yield return new Tracker()
                {
                    Id = entity.Id,
                    Location = entity.Location,
                    State = entity.State
                };
            }
        }
    }
}