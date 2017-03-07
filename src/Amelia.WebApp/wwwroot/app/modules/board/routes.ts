import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule, ActivatedRoute } from '@angular/router';

import { BoardComponent } from './components/board.component';

export const boardRoutes: Routes = [

    { path: 'projects/:slug/board', component: BoardComponent, data: { name: 'Kanban Board' } }

]
export const boardRouting:
    ModuleWithProviders = RouterModule.forChild(boardRoutes);
