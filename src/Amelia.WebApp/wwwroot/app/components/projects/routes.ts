import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ProjectsComponent } from './projects.component';
import { CreateProjectComponent } from './createProject.component';

export const projectRoutes: Routes = [
    {
        path: 'projects',
        component: ProjectsComponent,
        children: [
            { path: '', component: ProjectsComponent },
            { path: 'create', component: CreateProjectComponent }
        ]
    }
];

export const projectRouting: ModuleWithProviders = RouterModule.forChild(projectRoutes);