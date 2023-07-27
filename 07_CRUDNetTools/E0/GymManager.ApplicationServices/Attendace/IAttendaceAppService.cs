using GymManager.Accounts.Dto;
using GymManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.ApplicationServices.Attendace
{
    public interface IAttendaceAppService
    {
        Task<List<AttendanceDto>> GetAttendaceAsync();

        Task<AttendanceDto> AddAttendaceAsync(AttendanceDto Attendace);

        Task DeleteAttendaceAsync(int AttendaceId);

        Task<AttendanceDto> GetAttendaceAsync(int AttendaceId);

        Task EditAttendaceAsync(AttendanceDto Attendace);
    }
}
