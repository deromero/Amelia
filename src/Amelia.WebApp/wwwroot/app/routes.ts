import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './components/home.component';
import { ProjectsComponent } from './components/projects/projects.component';
import { accountRoutes, accountRouting } from './components/account/routes';


const appRoutes: Routes = [
    {
        path: '',
        redirectTo: '/home',
        pathMatch: 'full'
    },
    {
        path: 'home',
        component: HomeComponent
    }, 
    {
        path: 'projects',
        component: ProjectsComponent
    }
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);