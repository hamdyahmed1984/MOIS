using AutoMapper;
using ClientApp.Controllers.Resources;
using ClientApp.Controllers.Resources.Security;
using Domain.Entities;
using Domain.Entities.Documents;
using Domain.Entities.Security;
using Domain.ValueObjects;
using System.Collections.Generic;

namespace ClientApp.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<UserCredentialsResource, User>();
            CreateMap<RequestResourceIn, Request>()
                //.ForMember(dest => dest.DeliveryAddress.Governorate, act => act.Ignore())
                //.ForMember(dest => dest.DeliveryAddress.PoliceDepartment, act => act.Ignore())
                //.ForMember(dest => dest.DeliveryAddress.PostalCode, act => act.Ignore())
                //.ForMember(dest => dest.ResidencyAddress.Governorate, act => act.Ignore())
                //.ForMember(dest => dest.ResidencyAddress.PoliceDepartment, act => act.Ignore())
                //.ForMember(dest => dest.ResidencyAddress.PostalCode, act => act.Ignore())
                ;
            //.ForMember(src => src.NID, opt => opt.MapFrom(src => new NID(src.NID)));
            CreateMap<NIDResource, NID>();
            CreateMap<ContactDetailsResource, ContactDetails>();
            CreateMap<AddressResourceIn, Address>();
            CreateMap<RequesterNameResource, RequesterName>();

            CreateMap<CsrResource, CriminalStateRecord>();
            CreateMap<BirthDocResourceIn, BirthDoc>();
            CreateMap<DeathDocResourceIn, DeathDoc>();
            CreateMap<MarriageDocResourceIn, MarriageDoc>();
            CreateMap<DivorceDocResourceIn, DivorceDoc>();
            CreateMap<NidDocResourceIn, NidDoc>();
        }
    }
}
