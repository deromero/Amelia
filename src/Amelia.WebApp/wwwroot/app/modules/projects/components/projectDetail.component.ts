/// <reference path="../../../../../typings/globals/es6-shim/index.d.ts" />

import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params }   from '@angular/router';
import { Project } from '../../../core/domain/project';
import { Paginated } from '../../../core/common/paginated';
import { DataService } from '../../../core/services/data.service';
import { UtilityService } from '../../../core/services/utility.service';
import { NotificationService } from '../../../core/services/notification.service';
import { MembershipService } from '../../../core/services/membership.service';
import { User } from '../../../core/domain/user';

@Component({
    selector: 'am-project',
    templateUrl: './app/modules/projects/components/projectDetail.component.html'
})
export class ProjectDetailComponent implements OnInit {

    constructor(public projectService: DataService,
        public utilityService: UtilityService,
        public notificationService: NotificationService,
        public membershipService: MembershipService) { }

    ngOnInit(): void {
        /*
        this.route.params
            .switchMap((params: Params) => this.projectService.getBySlug(+params['slug']))
            .subscribe(project => this.project = project);*/
    }

}