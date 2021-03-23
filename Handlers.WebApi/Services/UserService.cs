using Handlers.Infrastructure.Interfaces;

namespace Handlers.WebApi.Services
{
    public class UserService:ICurrentUserService
    {
            public string Email => "test@email";
    }
}
