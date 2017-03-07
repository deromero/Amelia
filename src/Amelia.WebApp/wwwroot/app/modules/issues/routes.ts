import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule, ActivatedRoute } from '@angular/router';

import { IssuesComponent } from './components/issues.component';

export const issuesRoutes: Routes = [

    { path: 'projects/:slug/issues', component: IssuesComponent, data: { name: 'Issues' } }

]
export const issuesRouting:
    ModuleWithProviders = RouterModule.forChild(issuesRoutes);
