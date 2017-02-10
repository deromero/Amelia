/// <reference path="../../../../../typings/globals/es6-shim/index.d.ts" />

import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params }   from '@angular/router';
import { Project } from '../domain/project';
import { Paginated } from '../../../core/common/paginated';
import { DataService } from '../../../core/services/data.service';
import { UtilityService } from '../../../core/services/utility.service';
import { NotificationService } from '../../../core/services/notification.service';
import { MembershipService } from '../../../modules/account/services/membership.service';
import { User } from '../../../modules/account/domain/user';

@Component({
    selector: 'am-project',
    templateUrl: './app/modules/projects/components/projectDetail.component.html'
})
export class ProjectDetailComponent implements OnInit {

    public project: Project;

    constructor(public projectService: DataService,
        public utilityService: UtilityService,
        public notificationService: NotificationService,
        public membershipService: MembershipService) { }

    ngOnInit(): void {
        
        this.route.params
            .switchMap((params: Params) => this.projectService.getBySlug(params['slug']))
            .subscribe(project => this.project = project);
    }

}