import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule, ActivatedRoute } from '@angular/router';

import { BacklogComponent } from './components/backlog.component';

export const backlogRoutes: Routes = [

    { path: 'projects/:slug/backlog', component: BacklogComponent, data: { name: 'BackLog' } }

]
export const backlogRouting:
    ModuleWithProviders = RouterModule.forChild(backlogRoutes);
