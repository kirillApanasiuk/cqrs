using System.Threading.Tasks;

namespace ApplicationServices.Interfaces.Common
{
    public interface IReadOnlyEntityService<TDto>
    {
        Task<TDto> GetByIdAsync(int id);
      
    }
}