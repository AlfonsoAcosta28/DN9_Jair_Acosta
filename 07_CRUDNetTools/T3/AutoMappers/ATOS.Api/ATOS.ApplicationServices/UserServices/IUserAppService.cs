using ATOS.Accounts.Dto;
using ATOS.Core.Accounts;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATOS.ApplicationServices.UserServices
{
    public interface IUserAppService
    {
        Task<List<UserDto>> GetUsersAsync();

        Task<int> AddUsersAsync(User Users);

        Task DeleteUsersAsync(int UsersId);

        Task<UserDto> GetUsersAsync(int UsersId);

        Task EditUsersAsync(User Users);
    }
}
