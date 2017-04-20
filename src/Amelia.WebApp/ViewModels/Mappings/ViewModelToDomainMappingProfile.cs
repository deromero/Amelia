using System;
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
            MapTaskViewModelToTask();
            MapSprintViewModelToSprint();
        }

        private void MapSprintViewModelToSprint()
        {
            Mapper.CreateMap<SprintViewModel, Sprint>();
        }

        private void MapTaskViewModelToTask()
        {
            Mapper.CreateMap<TaskViewModel, Task>();
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