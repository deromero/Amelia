
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { Project } from '../../../modules/projects/domain/project';
import { ProjectService } from '../../projects/services/project.service';
import { Paginated } from '../../../core/common/paginated';
import { DataService } from '../../../core/services/data.service';
import { UtilityService } from '../../../core/services/utility.service';
import { NotificationService } from '../../../core/services/notification.service';

import { Subscription } from 'rxjs/Subscription';

@Component({
    selector: 'backlog',
    templateUrl: './app/modules/backlog/components/backlog.component.html'
})
export class BacklogComponent implements OnInit {

    private _project: Project;
    private _projectSlug: string;
    private sub: Subscription;

    constructor(public projectService: ProjectService,
        public utilityService: UtilityService,
        public notificationService: NotificationService,
        private route: ActivatedRoute,
        private router: Router) {
    }

    ngOnInit(): void {
        this.sub = this.route.params.subscribe(params => {
            this._projectSlug = params["slug"];
            this.getProject();
        })
    }

    getProject(): void {
        this.projectService.getBySlug(this._projectSlug)
            .subscribe(res => {
                var data: any = res.json();
                this._project = data;
                //TODO: GetBacklog
                
            }, error => {
                this.notificationService.printErrorMessage(error);
            });
    }

}