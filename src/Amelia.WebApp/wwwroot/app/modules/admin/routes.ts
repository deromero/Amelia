import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule, ActivatedRoute } from '@angular/router';

import { AdminComponent } from './components/admin.component';

export const adminRoutes: Routes = [

    { path: 'projects/:slug/admin', component: AdminComponent, data: { name: 'Admin' } }

]
export const adminRouting:
    ModuleWithProviders = RouterModule.forChild(adminRoutes);
