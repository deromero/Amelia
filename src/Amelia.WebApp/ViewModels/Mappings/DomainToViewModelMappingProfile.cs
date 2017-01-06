using Amelia.Domain.Models;
using AutoMapper;

namespace Amelia.WebApp.ViewModels.Mappings
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