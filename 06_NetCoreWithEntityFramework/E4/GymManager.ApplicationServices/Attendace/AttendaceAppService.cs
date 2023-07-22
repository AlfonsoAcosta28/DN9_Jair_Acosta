using GymManager.Core.Entities;
using GymManager.DataAcces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GymManager.ApplicationServices.Attendace
{
    public class AttendaceAppService : IAttendaceAppService
    {
        private readonly IRepository<int, Attendance> _repository;
        public AttendaceAppService(IRepository<int, Attendance> repository)
        {
            _repository = repository;
        }

        public async Task<int> AddAttendaceAsync(Attendance Attendace)
        {
            await _repository.AddAsync(Attendace);
            return Attendace.Id;
        }

        public async Task DeleteAttendaceAsync(int AttendaceId)
        {
            await _repository.DeleteAsync(AttendaceId);
        }

        public async Task EditAttendaceAsync(Attendance Attendace)
        {
            await _repository.UpdateAsync(Attendace);
        }

        public async Task<Attendance> GetAttendaceAsync(int AttendaceId)
        {
            return await _repository.GetAsync(AttendaceId);
        }

        public async Task<List<Attendance>> GetAttendaceAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }


    }
}
