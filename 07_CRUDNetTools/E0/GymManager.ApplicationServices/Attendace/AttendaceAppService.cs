using GymManager.Core.Entities;
using GymManager.DataAcces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GymManager.Accounts.Dto;
using AutoMapper;

namespace GymManager.ApplicationServices.Attendace
{
    public class AttendaceAppService : IAttendaceAppService
    {
        private readonly IRepository<int, Attendance> _repository;
        private readonly IMapper _mapper;
        public AttendaceAppService(IRepository<int, Attendance> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AttendanceDto> AddAttendaceAsync(AttendanceDto Attendace)
        {
            var element = _mapper.Map<Attendance>(Attendace);
            await _repository.AddAsync(element);
            return Attendace;
        }

        public async Task DeleteAttendaceAsync(int AttendaceId)
        {
            await _repository.DeleteAsync(AttendaceId);
        }

        public async Task EditAttendaceAsync(AttendanceDto Attendace)
        {
            var element = _mapper.Map<Attendance>(Attendace);
            await _repository.UpdateAsync(element);
        }

        public async Task<AttendanceDto> GetAttendaceAsync(int AttendaceId)
        {
            var element = await _repository.GetAsync(AttendaceId);
            var attendaceDto = _mapper.Map<AttendanceDto>(element);
            return attendaceDto;

        }

        public async Task<List<AttendanceDto>> GetAttendaceAsync()
        {
            var element = await _repository.GetAll().ToListAsync();
            var listAttendanceDto = _mapper.Map<List<AttendanceDto>>(element); 
            return listAttendanceDto;
        }


    }
}
