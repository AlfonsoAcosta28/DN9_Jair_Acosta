using ATOS.Accounts.Dto;
using ATOS.ApplicationServices.ProfileServices;
using ATOS.Core.Accounts;
using ATOS.DataAccess.Repositotories;
using AutoMapper;
using AutoMapper.Execution;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATOS.ApplicationServices.UserServices
{
    public class ProfilesAppService : IProfilesAppService
    {
        private readonly IRepository<int, Core.Accounts.Profile> _repository;
        private readonly IMapper _mapper;
        public ProfilesAppService(IRepository<int, Core.Accounts.Profile> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;   
        }
        public async Task<int> AddProfilesAsync(ProfileDto Profiles)
        {
            var p = _mapper.Map<Core.Accounts.Profile>(Profiles); 
            await _repository.AddAsync(p);
            return Profiles.Id;
        }

        public async Task DeleteProfilesAsync(int ProfilesId)
        {
            await _repository.DeleteAsync(ProfilesId);
        }

        public async Task EditProfilesAsync(ProfileDto Profiles)
        {
            var p = _mapper.Map<Core.Accounts.Profile>(Profiles);
            await _repository.UpdateAsync(p);
        }

        public async Task<List<ProfileDto>> GetProfilesAsync()
        { 
            var users = _mapper.Map<List<ProfileDto>>(await _repository.GetAll().ToListAsync());
            return users;
        }

        public async Task<ProfileDto> GetProfilesAsync(int ProfilesId)
        {
            var users = _mapper.Map<ProfileDto>(await _repository.GetAsync(ProfilesId));
            return users;
        }
    }
}
