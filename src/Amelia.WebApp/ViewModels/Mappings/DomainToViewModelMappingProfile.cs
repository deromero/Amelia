using System;
using Amelia.Domain.Models;
using AutoMapper;

namespace Amelia.WebApp.ViewModels.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            MapUserToUserViewModel();
            MapProjectToProjectViewModel();
            MapTaskToTaskViewModel();
            MapSprintToSprintViewModel();
        }

        private void MapTaskToTaskViewModel()
        {
            Mapper.CreateMap<Task, TaskViewModel>();
        }

        private void MapSprintToSprintViewModel()
        {
            Mapper.CreateMap<Sprint, SprintViewModel>();
        }

        private void MapProjectToProjectViewModel()
        {
            Mapper.CreateMap<Project, ProjectViewModel>();
        }

        private void MapUserToUserViewModel()
        {
            Mapper.CreateMap<User, RegistrationViewModel>();
        }
    }

}