using AutoMapper;
using GymManager.Accounts.Dto;
using GymManager.Core.Entities;
using GymManager.Core.Members;
using GymManager.Core.MembershipTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.ApplicationServices
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {  
            //Attendance
            CreateMap<Attendance, AttendanceDto>();
            CreateMap<AttendanceDto, Attendance>();
            
            //City
            CreateMap<City, CityDto>();
            CreateMap<CityDto, City>();

            //EquipamentType
            CreateMap<EquipmentType, EquipmentTypeDto>();
            CreateMap<EquipmentTypeDto, EquipmentType>();

            //Inventory
            CreateMap<Inventory, InventoryDto>();
            CreateMap<InventoryDto, Inventory>();

            //Meausre
            CreateMap<Measuretype, MeasuretypeDto>();
            CreateMap<MeasuretypeDto, Measuretype>();

            //Member
            CreateMap<Member, MemberDto>();
            CreateMap<MemberDto, Member>();

            //MemberShipType
            CreateMap<MembershipType, MembershipTypeDto>();
            CreateMap<MembershipTypeDto, MembershipType>();

            //ProductoTypes
            CreateMap<ProductTypes, ProductTypesDto>();
            CreateMap<ProductTypesDto, ProductTypes>();

            //SaleLine
            CreateMap<SaleLine, SaleLineDto>();
            CreateMap<SaleLineDto, SaleLine>();

            //Sale
            CreateMap<Sales, SalesDto>();
            CreateMap<SalesDto, Sales>();

            //Types
            CreateMap<Types, TypesDto>();
            CreateMap<TypesDto, Types>();
        }
    }
}
