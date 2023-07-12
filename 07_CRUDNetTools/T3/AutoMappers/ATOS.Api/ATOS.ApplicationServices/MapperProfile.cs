
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATOS.ApplicationServices
{
    public class MapperProfile : Profile
    {
        public MapperProfile() {
            CreateMap<ATOS.Core.Accounts.User, ATOS.Accounts.Dto.UserDto> ()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.UserName));

            CreateMap<ATOS.Core.Accounts.Profile, ATOS.Accounts.Dto.ProfileDto>();
            CreateMap<ATOS.Accounts.Dto.ProfileDto, ATOS.Core.Accounts.Profile>();
        }
    }
}
