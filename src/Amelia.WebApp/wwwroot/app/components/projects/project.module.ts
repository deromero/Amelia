import { NgModule }       from '@angular/core';
import { FormsModule }    from '@angular/forms';
import { CommonModule }   from '@angular/common';

import { DataService } from '../../core/services/data.service';
import { ProjectService } from '../../core/services/project.service';
import { NotificationService } from '../../core/services/notification.service';

import { ProjectComponent } from './project.component';
import { ProjectsComponent } from './projects.component';
import { CreateProjectComponent } from './createProject.component';

import { projectRouting } from './routes';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        projectRouting
    ],
    declarations: [
        ProjectComponent,
        ProjectsComponent,
        CreateProjectComponent
    ],
    providers: [
        DataService,
        ProjectService,
        NotificationService
    ]
})
export class ProjectModule {  }

