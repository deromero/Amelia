import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

import { SharedModule } from '../../modules/shared/shared.module';

import { SettingsComponent } from './components/settings.component';

import { DataService } from '../../core/services/data.service';
import { NotificationService } from '../../core/services/notification.service';

import { settingsRouting } from './routes';

@NgModule({
    imports:[
        CommonModule,
        FormsModule,
        SharedModule,
        settingsRouting
    ],
    declarations: [
        SettingsComponent 
    ],
    providers :[
        DataService,
        NotificationService
    ]
})
export class SettingsModule { }