using TaskManager.API.core.DTO;
using TaskManager.API.Core.Identity;

namespace TaskManager.API.core.ServiceContracts
{
    public interface IJWTService
    {
        public interface IJwtService
        {
            AuthenticationResponse CreateJwtToken(ApplicationUser user);
        }
    }
}
