using AutoMapper;
using Base.Entities.Models;
using Base.Services.Implementation.Account;
using Base.Services.Implementation.Complaints;

namespace Base.Core
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            //CreateMap<Model, Dto>();
            //CreateMap<Dto, Model>();

            CreateMap<UserModel, AccountDTO>();
            CreateMap<AccountDTO, UserModel>();

            CreateMap<UserModel, AbsoluteAccountDTO>();
            CreateMap<AbsoluteAccountDTO, UserModel>();

            CreateMap<ComplaintsModel, AbsoluteComplaintsDTO>();
            CreateMap<AbsoluteComplaintsDTO, ComplaintsModel>();

        }
    }
}
