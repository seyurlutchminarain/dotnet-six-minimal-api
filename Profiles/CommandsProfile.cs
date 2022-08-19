using AutoMapper;
using SixMinApi.Dtos;
using SixMinApi.Models;

namespace SixMinApi.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            // Source -> Target
            CreateMap<ClientModel, ClientReadDto>();
            CreateMap<ClientCreateDto, ClientModel>();
            CreateMap<ClientUpdateDto, ClientModel>();
            CreateMap<AddressModel, AddressReadDto>();
            CreateMap<AddressCreateDto, AddressModel>();
            CreateMap<AddressUpdateDto, AddressModel>();
            CreateMap<BankAccountModel, BankModelReadDto>();
            CreateMap<BankModelCreateDto, BankAccountModel>();
            CreateMap<BankModelUpdateDto, BankAccountModel>();
            CreateMap<DependantModel, DependantReadDto>();
            CreateMap<DependantCreateDto, DependantModel>();
            CreateMap<DependantUpdateDto, DependantModel>();
            CreateMap<BeneficiaryModel, BeneficiaryReadDto>();
            CreateMap<BeneficiaryCreateDto, BeneficiaryModel>();
            CreateMap<BeneficiaryUpdateDto, BeneficiaryModel>();
        }
    }
}