import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule, ActivatedRoute } from '@angular/router';

import { ProjectsComponent } from './components/projects.component';
import { ProjectDetailComponent } from './components/projectDetail.component';
import { CreateProjectComponent } from './components/createProject.component';

export const projectRoutes: Routes = [
    { path: 'projects', component: ProjectsComponent },
    { path: 'project/new', component: CreateProjectComponent },
    { path: 'project/:slug/show', component: ProjectDetailComponent }
]
export const projectRouting:
    ModuleWithProviders = RouterModule.forChild(projectRoutes);