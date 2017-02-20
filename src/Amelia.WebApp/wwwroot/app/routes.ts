import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './components/home.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { accountRoutes, accountRouting } from './modules/account/routes';
import { projectRoutes, projectRouting } from './modules/projects/routes';
import { settingsRoutes, settingsRouting } from './modules/settings/routes';
import { sharedRoutes, sharedRouting } from './modules/shared/routes';


const appRoutes: Routes = [
    { path: '', redirectTo: '/home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent, data: { name: 'Home' } },
    { path: 'dashboard', component: DashboardComponent, data: { name: 'Dashboard' } }
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);