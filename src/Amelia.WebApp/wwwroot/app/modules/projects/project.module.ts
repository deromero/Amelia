import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

import { SharedModule } from '../../modules/shared/shared.module';

import { DataService } from '../../core/services/data.service';
import { ProjectService } from './services/project.service';
import { NotificationService } from '../../core/services/notification.service';
import { UtilityService } from '../../core/services/utility.service';

import { ProjectsComponent } from './components/projects.component';
import { ProjectDetailComponent } from './components/projectDetail.component';
import { CreateProjectComponent } from './components/createProject.component';
import { SidebarComponent } from './components/sidebar.component';

import { projectRouting } from './routes';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        projectRouting,
        SharedModule
    ],
    declarations: [
        ProjectsComponent,
        ProjectDetailComponent,
        CreateProjectComponent,
        SidebarComponent
    ],
    providers: [
        DataService,
        ProjectService,
        NotificationService,
        UtilityService
    ],
    exports: [
        SidebarComponent
    ]
})
export class ProjectModule { }