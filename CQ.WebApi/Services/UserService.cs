using CQ.Infrastructure.Interfaces;

namespace CQ.WebApi.Services
{
    public class UserService:ICurrentUserService
    {
            public string Email => "test@email";
    }
}
