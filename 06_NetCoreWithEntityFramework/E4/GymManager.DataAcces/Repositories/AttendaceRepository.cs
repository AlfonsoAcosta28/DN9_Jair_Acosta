using GymManager.Core.Entities;
using GymManager.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.DataAcces.Repositories
{
    public class AttendaceRepository : Repository<int, Attendance>
    {
        public AttendaceRepository(GymManagerContext gymManagerContext) : base(gymManagerContext)
        {
            
        }

        public override async Task<Attendance> AddAsync(Attendance entity)
        {
            
            var member = Context.Members.Find(entity.Member.Id);
            entity.Member = null;
            await Context.Attendances.AddAsync(entity);
            member.Attendances.Add(entity);
            Context.SaveChanges();
            return entity;
        }
    }
}
