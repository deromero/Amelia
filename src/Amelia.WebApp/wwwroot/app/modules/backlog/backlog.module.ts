import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

import { SharedModule } from '../../modules/shared/shared.module';

import { DataService } from '../../core/services/data.service';
import { ProjectService } from '../../modules/projects/services/project.service';
import { SprintService } from './services/sprint.service';
import { NotificationService } from '../../core/services/notification.service';
import { UtilityService } from '../../core/services/utility.service';

import { BacklogComponent } from './components/backlog.component';
import { SprintsComponent } from './components/sprints.component';

import { backlogRouting } from './routes';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        backlogRouting,
        SharedModule
    ],
    declarations: [
        BacklogComponent,
        SprintsComponent
    ],
    providers: [
        DataService,
        ProjectService,
        SprintService,
        NotificationService,
        UtilityService
    ]
})
export class BacklogModule { }