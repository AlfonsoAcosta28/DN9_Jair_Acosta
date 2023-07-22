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
        Task<List<Attendance>> GetAttendaceAsync();

        Task<int> AddAttendaceAsync(Attendance Attendace);

        Task DeleteAttendaceAsync(int AttendaceId);

        Task<Attendance> GetAttendaceAsync(int AttendaceId);

        Task EditAttendaceAsync(Attendance Attendace);
    }
}
