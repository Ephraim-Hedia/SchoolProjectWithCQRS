using SchoolProject.Core.Features.ApplicationUser.Queries.Results;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Core.Mapping.ApplicationUserMapping
{
    public partial class ApplicationUserProfile
    {
        public void GetUserPaginatedMapping()
        {
            CreateMap<User, GetUserPaginatedResponse>();

        }
    }
}
