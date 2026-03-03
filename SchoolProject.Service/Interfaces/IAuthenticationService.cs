using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Service.Interfaces
{
    public interface IAuthenticationService
    {
        public Task<string> GetJwtToken(User user);
    }
}
