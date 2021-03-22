using Infrastructure.Interfaces;

namespace Layers.WebApi.Services
{
    public class UserService : ICurrentUserService
    {
        public string Email => "test@email";
    }
}
