import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule, ActivatedRoute } from '@angular/router';

import { TeamComponent } from './components/team.component';

export const teamRoutes: Routes = [

    { path: 'projects/:slug/team', component: TeamComponent, data: { name: 'Team' } }

]
export const teamRouting:
    ModuleWithProviders = RouterModule.forChild(teamRoutes);
