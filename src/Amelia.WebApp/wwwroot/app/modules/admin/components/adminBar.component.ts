
/// <reference path="../../../../../typings/globals/es6-shim/index.d.ts" />

import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { Router, ActivatedRoute, NavigationStart, NavigationEnd, Params, PRIMARY_OUTLET } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/filter';
import { enableProdMode } from '@angular/core';

import { Project } from '../../projects/domain/project';
import { ProjectService } from '../../projects/services/project.service';
import { DataService } from '../../../core/services/data.service';
import { UtilityService } from '../../../core/services/utility.service';
import { NotificationService } from '../../../core/services/notification.service';

@Component({
    selector: 'admin-bar',
    templateUrl: './app/modules/admin/components/adminBar.component.html'
})
export class AdminBarComponent implements OnInit {

    private _project: Project;
    private _projectSlug: string;
    private _hasProject: boolean = false;

    constructor(public projectService: ProjectService,
        public utilityService: UtilityService,
        public notificationService: NotificationService,
        public location: Location,
        private route: ActivatedRoute,
        private router: Router) {
    }

    ngOnInit(): void {

        this.router.events
            .filter(event => event instanceof NavigationEnd)
            .subscribe(event => {
                let currentRoute: ActivatedRoute = this.route.root;
                while (currentRoute.children[0] !== undefined) {
                    currentRoute = currentRoute.children[0];
                }

                currentRoute.params.subscribe(params => {
                    this._projectSlug = params['slug'];
                    if (this._projectSlug !== undefined) {
                        this.getProject();
                    }
                    else {
                        this._hasProject = false;
                        this._project = undefined;
                    }
                });
            });
    }

    getProject(): void {
        this.projectService.getBySlug(this._projectSlug)
            .subscribe(res => {
                var data: any = res.json();
                this._project = data;
                this._hasProject = this._project != undefined;
            }, error => {
                this.notificationService.printErrorMessage(error);
            });
    }

}