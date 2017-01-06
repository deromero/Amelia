using Amelia.Domain.Models;
using AutoMapper;

namespace Amelia.WebApi.ViewModels.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            //TODO: Create Maps
            MapUserViewModelToUser();
        }

        private void MapUserViewModelToUser()
        {
            Mapper.CreateMap<UserViewModel,User>();
        }
    }

}