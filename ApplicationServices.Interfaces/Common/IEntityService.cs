using System.Threading.Tasks;

namespace ApplicationServices.Interfaces.Common
{
    public interface IEntityService<TDto>
    {
        Task<int> CreateEntityAsync(TDto dto);
        Task UpdateEntityAsync(int id,TDto dto);
        Task DeleteEntityAsync(int id);
    }
}
