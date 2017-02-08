import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

import { DataService } from '../../core/services/data.service';
import { MembershipService } from '../../modules/account/services/membership.service';
import { NotificationService } from '../../core/services/notification.service';

import { ProjectsComponent } from './components/projects.component';
import { ProjectDetailComponent } from './components/projectDetail.component';
import { CreateProjectComponent } from './components/createProject.component';

import { projectRouting } from './routes';

@NgModule({
    imports:[
        CommonModule,
        FormsModule,
        projectRouting
    ],
    declarations: [
        ProjectsComponent,
        ProjectDetailComponent,
        CreateProjectComponent
    ],
    providers :[
        DataService,
        MembershipService,
        NotificationService
    ]
})
export class ProjectModule { }