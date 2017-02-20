import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule, ActivatedRoute } from '@angular/router';

import { SettingsComponent } from './components/settings.component';

export const settingsRoutes: Routes = [
    { path: 'settings', component: SettingsComponent, data: { name: 'Settings' } }
]
export const settingsRouting:
    ModuleWithProviders = RouterModule.forChild(settingsRoutes);