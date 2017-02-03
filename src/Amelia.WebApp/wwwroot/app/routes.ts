import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './components/home.component';
import { accountRoutes, accountRouting } from './modules/account/routes';
import { projectRoutes, projectRouting } from './modules/projects/routes';


const appRoutes: Routes = [
    {
        path: '',
        redirectTo: '/home',
        pathMatch: 'full'
    },
    { path: 'home', component: HomeComponent }
    
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);