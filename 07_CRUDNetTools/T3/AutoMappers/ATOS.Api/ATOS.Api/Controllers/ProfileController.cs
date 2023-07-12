using ATOS.Accounts.Dto;
using ATOS.ApplicationServices.ProfileServices;
using Microsoft.AspNetCore.Mvc;

namespace ATOS.Api.Controllers
{
    [ApiController]
    public class ProfileController : Controller
    
    {
        private readonly IProfilesAppService _profilesAppService;
        Serilog.ILogger _logger;

        public ProfileController(IProfilesAppService profileAppService, Serilog.ILogger logger)
        {
            _logger = logger;
            _profilesAppService = profileAppService;
        }
        [HttpGet]
        public async Task<List<ProfileDto>> Get()
        {
            List<ProfileDto> profiles = await _profilesAppService.GetProfilesAsync();
            _logger.Information("Total profiles retieved: " + profiles);
            return profiles;
        }

        [HttpGet("{id}")]
        public async Task<ProfileDto> Get(int id)
        {
            ProfileDto profile = await _profilesAppService.GetProfilesAsync(id);
            _logger.Information("Get profile: " + id);
            return profile;
        }
        [HttpPost]
        public async Task<Int32> Post(ProfileDto entity)
        {
            var result = await _profilesAppService.AddProfilesAsync(entity);
            _logger.Information("New profile created: " + entity);
            return result;
        }
        [HttpPut("{id}")]
        public async Task Put(int id, ProfileDto entity)
        {
            await _profilesAppService.EditProfilesAsync(entity);
            _logger.Information("New profile created: " + entity);
        }
    }
}
