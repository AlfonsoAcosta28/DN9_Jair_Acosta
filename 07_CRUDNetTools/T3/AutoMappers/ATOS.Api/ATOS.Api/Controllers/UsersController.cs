using ATOS.Accounts.Dto;
using ATOS.ApplicationServices.UserServices;
using ATOS.Core.Accounts;
using Microsoft.AspNetCore.Mvc;

namespace ATOS.Api.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserAppService _usersAppService;
        Serilog.ILogger _logger;

        public UsersController(IUserAppService userAppService, Serilog.ILogger logger)
        {
            _logger = logger;
            _usersAppService = userAppService;
        }
        [HttpGet]
        public async Task<List<UserDto>> Get()
        {
            List<UserDto> users = await _usersAppService.GetUsersAsync();
            _logger.Information("Total users retieved: " + users?.Count());
            return users;
        }

        [HttpGet("{id}")]
        public async Task<UserDto> Get(int id)
        {
            UserDto user = await _usersAppService.GetUsersAsync(id);
            _logger.Information("Get User: " + id);
            return user;
        }
    }
}
