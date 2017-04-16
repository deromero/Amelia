import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Project } from '../domain/project';
import { ProjectService } from '../services/project.service';
import { NotificationService } from '../../../core/services/notification.service';
import { UtilityService } from '../../../core/services/utility.service';
import { Subscription } from 'rxjs/Subscription';

@Component({
    selector: 'project-Detail',
    providers: [ProjectService, NotificationService],
    templateUrl: './app/modules/projects/components/projectDetail.component.html'
})
export class ProjectDetailComponent implements OnInit {

    private _project: Project;
    private _projectSlug: string;
    private sub: Subscription;

    constructor(public projectService: ProjectService,
        public notificationService: NotificationService,
        private route: ActivatedRoute,
        private router: Router) { }

    ngOnInit(): void {
        this.sub = this.route.params.subscribe(params => {
            this._projectSlug = params['slug'];
            this.getProject();
        });
    }

    getProject(): void {
        this.projectService.getBySlug(this._projectSlug)
            .subscribe(res => {
                var data: any = res.json();
                this._project = data;
            }, error => {
                this.notificationService.printErrorMessage(error);
            });
    }

};