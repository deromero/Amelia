import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

import { SharedModule } from '../../modules/shared/shared.module';

import { DataService } from '../../core/services/data.service';
import { ProjectService } from './services/project.service';
import { NotificationService } from '../../core/services/notification.service';

import { ProjectsComponent } from './components/projects.component';
import { ProjectDetailComponent } from './components/projectDetail.component';
import { CreateProjectComponent } from './components/createProject.component';

import { projectRouting } from './routes';

@NgModule({
    imports:[
        CommonModule,
        FormsModule,
        projectRouting,
        SharedModule
    ],
    declarations: [
        ProjectsComponent,
        ProjectDetailComponent,
        CreateProjectComponent
    ],
    providers :[
        DataService,
        ProjectService,
        NotificationService
    ]
})
export class ProjectModule { }