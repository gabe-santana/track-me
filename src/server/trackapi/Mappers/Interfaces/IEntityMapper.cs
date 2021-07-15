using System.Collections.Generic;

namespace trackapi.Mappers.Interfaces
{

    public interface IEntityMapper<TEntity, TEntityDTO> where  TEntity : class
    {
        TEntity ToEntity(TEntityDTO entityDTO);
        TEntityDTO ToDTO(TEntity entity);
        IEnumerable<TEntityDTO> ToDTOList(IEnumerable<TEntity> entities);
        IEnumerable<TEntity> ToEntityList(IEnumerable<TEntityDTO> entityDTOs);
    }
}