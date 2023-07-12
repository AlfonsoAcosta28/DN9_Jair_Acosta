using ATOS.Accounts.Dto;
using ATOS.Core.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATOS.ApplicationServices.ProfileServices
{
    public interface IProfilesAppService
    {
        Task<List<ProfileDto>> GetProfilesAsync();

        Task<int> AddProfilesAsync(ProfileDto Profiles);

        Task DeleteProfilesAsync(int ProfilesId);

        Task<ProfileDto> GetProfilesAsync(int ProfilesId);

        Task EditProfilesAsync(ProfileDto Profiles);
    }
}
