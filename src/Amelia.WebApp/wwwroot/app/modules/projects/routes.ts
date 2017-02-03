import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ProjectsComponent } from './components/projects.component';
import { ProjectDetailComponent } from './components/projectDetail.component';
import { CreateProjectComponent } from './components/createProject.component';

export const projectRoutes: Routes = [
    {
        path: 'projects',
        component: ProjectsComponent,

    },
    {
        path: 'projects/:slug',
        component: ProjectDetailComponent,
    },
    {
        path: 'projects/create',
        component: CreateProjectComponent
    }
];

export const projectRouting:
    ModuleWithProviders = RouterModule.forChild(projectRoutes);