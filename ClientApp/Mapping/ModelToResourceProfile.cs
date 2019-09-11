using Application.Security.Tokens;
using AutoMapper;
using ClientApp.Controllers.Resources;
using ClientApp.Controllers.Resources.Lookups;
using ClientApp.Controllers.Resources.Security;
using Domain;
using Domain.Entities;
using Domain.Entities.Documents;
using Domain.Entities.Lookups;
using Domain.Entities.Security;
using Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace ClientApp.Mapping
{
    public class ModelToResourceProfile: Profile
    {
        public ModelToResourceProfile()
        {
            #region Security
            CreateMap<User, UserResource>()
                .ForMember(u => u.Roles, opt => opt.MapFrom(u => u.UserRoles.Select(ur => ur.Role.Name)));

            CreateMap<AccessToken, AccessTokenResource>()
                .ForMember(a => a.AccessToken, opt => opt.MapFrom(a => a.Token))
                .ForMember(a => a.RefreshToken, opt => opt.MapFrom(a => a.RefreshToken.Token))
                .ForMember(a => a.Expiration, opt => opt.MapFrom(a => a.Expiration));
            #endregion

            CreateMap<LookupBase, LookupBaseResource>();
            CreateMap<Governorate, LookupBaseResource>();
            CreateMap<PoliceDepartment, PoliceDepartmentResource>();
            CreateMap<PostalCode, PostalCodeResource>();
            CreateMap<Regulation, RegulationResource>()
            .ForMember(a => a.DocTypeCode, opt => opt.MapFrom(a => a.DocumentType.Code));;

            CreateMap<Request, RequestResourceOut>()
                .ForMember(a => a.RequesterFullName, opt => opt.MapFrom(a => a.Name.FirstName))
                .ForMember(a => a.Id, opt => opt.Condition(a => a.Id > 0));

            CreateMap<Request, RequestStateResource>()
                .ForMember(a => a.State, opt => opt.MapFrom(a => a.RequestStates.LastOrDefault().State));

            CreateMap<NID, NIDResource>();
            CreateMap<ContactDetails, ContactDetailsResource>();
            CreateMap<Address, AddressResourceOut>();
            CreateMap<RequesterName, RequesterNameResource>();


            CreateMap<CriminalStateRecord, CsrResource>();

            CreateMap<BirthDoc, BirthDocResourceOut>()
                .ForMember(a => a.NID, opt => opt.Condition(a => !a.IsFirstTime))
                .ForMember(a => a.Id, opt => opt.Condition(a => a.Id > 0))
                .ForMember(a => a.RequestId, opt => opt.Condition(a => a.RequestId > 0));
            CreateMap<BirthDoc, BirthDocStateResource>();

            CreateMap<DeathDoc, DeathDocResourceOut>()
                .ForMember(a => a.NID, opt => opt.Condition(a => a.NID != null && a.NID.NationalIdenNumber != Constants.DEFAULT_NID_NUMBER))
                .ForMember(a => a.Id, opt => opt.Condition(a => a.Id > 0))
                .ForMember(a => a.RequestId, opt => opt.Condition(a => a.RequestId > 0));
            CreateMap<DeathDoc, DeathDocStateResource>();

            CreateMap<MarriageDoc, MarriageDocResourceOut>()
                .ForMember(a => a.Id, opt => opt.Condition(a => a.Id > 0))
                .ForMember(a => a.RequestId, opt => opt.Condition(a => a.RequestId > 0));
            CreateMap<MarriageDoc, MarriageDocStateResource>();

            CreateMap<DivorceDoc, DivorceDocResourceOut>()
                .ForMember(a => a.Id, opt => opt.Condition(a => a.Id > 0))
                .ForMember(a => a.RequestId, opt => opt.Condition(a => a.RequestId > 0));
            CreateMap<DivorceDoc, DivorceDocStateResource>();

            CreateMap<NidDoc, NidDocResourceOut>()
                .ForMember(a => a.Id, opt => opt.Condition(a => a.Id > 0))
                .ForMember(a => a.RequestId, opt => opt.Condition(a => a.RequestId > 0));
            CreateMap<NidDoc, NidDocStateResource>();
        }
    }
}
