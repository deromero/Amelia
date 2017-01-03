using System;
using Amelia.WebApi.Models.Entities;
using AutoMapper;

namespace Amelia.WebApi.ViewModels.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            MapUserToUserViewModel();
        }

        private void MapUserToUserViewModel()
        {
            Mapper.CreateMap<User, UserViewModel>();
        }
    }

}