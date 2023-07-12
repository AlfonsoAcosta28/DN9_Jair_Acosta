using ATOS.Accounts.Dto;
using ATOS.Core.Accounts;
using ATOS.DataAccess.Repositotories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATOS.ApplicationServices.UserServices
{
    public class UserAppService : IUserAppService
    {
        private readonly IRepository<int, User> _repository;
        private readonly IMapper _mapper;
        public UserAppService(IRepository<int, User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<int> AddUsersAsync(User Users)
        {
            await _repository.AddAsync(Users);
            return Users.Id;
        }

        public async Task DeleteUsersAsync(int UsersId)
        {
            await _repository.DeleteAsync(UsersId);
        }

        public  async Task EditUsersAsync(User Users)
        {
            await _repository.UpdateAsync(Users);
        }

        public async Task<List<UserDto>> GetUsersAsync()
        {
            var u = await _repository.GetAll().ToListAsync();

            List<UserDto> users = _mapper.Map<List<UserDto>>(u);

            /* foreach(var user in u)
             {
                 users.Add(new UserDto
                 {
                     CreatedDate = user.CreatedDate,
                     Id = user.Id,
                     IdEmploye = user.IdEmploye,
                     Status = user.Status,
                     UpdatedDate = user.UpdatedDate,
                     UserName = user.UserName
                 });
             }
            */
            return users;
        }

        public async Task<UserDto> GetUsersAsync(int UsersId)
        {
            var user = await _repository.GetAsync(UsersId);
            UserDto dto = _mapper.Map<UserDto>(user);
         /*   UserDto userDto = new UserDto
            {
                CreatedDate = user.CreatedDate,
                Id = user.Id,
                IdEmploye = user.IdEmploye,
                Status = user.Status,
                UpdatedDate = user.UpdatedDate,
                UserName = user.UserName
            };*/
            return dto;
        }
    }
}
