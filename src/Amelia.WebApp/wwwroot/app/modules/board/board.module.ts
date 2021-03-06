import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

import { SharedModule } from '../../modules/shared/shared.module';

import { DataService } from '../../core/services/data.service';
import { ProjectService } from '../../modules/projects/services/project.service';
import { NotificationService } from '../../core/services/notification.service';
import { UtilityService } from '../../core/services/utility.service';

import { BoardComponent } from './components/board.component';

import { boardRouting } from './routes';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        boardRouting,
        SharedModule
    ],
    declarations: [
        BoardComponent
    ],
    providers: [
        DataService,
        ProjectService,
        NotificationService,
        UtilityService
    ]
})
export class BoardModule { }