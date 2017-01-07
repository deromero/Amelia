using Amelia.Domain.Models;
using AutoMapper;

namespace Amelia.WebApp.ViewModels.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            //TODO: Create Maps
            MapUserViewModelToUser();
            MapProjectViewModelToProject();
        }

        private void MapProjectViewModelToProject()
        {
            Mapper.CreateMap<ProjectViewModel,Project>();
        }

        private void MapUserViewModelToUser()
        {
            Mapper.CreateMap<RegistrationViewModel,User>();
        }
    }

}