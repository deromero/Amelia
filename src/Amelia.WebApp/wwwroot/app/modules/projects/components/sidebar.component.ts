/// <reference path="../../../../../typings/globals/es6-shim/index.d.ts" />

import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { Router, ActivatedRoute, NavigationStart, NavigationEnd, Params, PRIMARY_OUTLET } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/filter';
import { enableProdMode } from '@angular/core';

enableProdMode();
import { MembershipService } from '../../../modules/account/services/membership.service';
import { NotificationService } from '../../../core/services/notification.service';
import { User } from '../../../modules/account/domain/user';
import { Project } from '../domain/project';
import { ProjectService } from '../services/project.service';
import { Subscription } from 'rxjs/Subscription';


@Component({
    selector: 'am-sidebar',
    providers: [ProjectService],
    templateUrl: './app/modules/projects/components/sidebar.component.html'
})
export class SidebarComponent implements OnInit {

    private _project: Project;
    private _projectSlug: string;
    private sub: Subscription;
    private _hasProject: boolean = false;

    constructor(public projectService: ProjectService,
        public notificationService: NotificationService,
        public location: Location,
        private route: ActivatedRoute,
        private router: Router) { }

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
                    else{
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