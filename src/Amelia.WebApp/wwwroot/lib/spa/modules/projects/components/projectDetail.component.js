/// <reference path="../../../../../typings/globals/es6-shim/index.d.ts" />
"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require('@angular/core');
var data_service_1 = require('../../../core/services/data.service');
var utility_service_1 = require('../../../core/services/utility.service');
var notification_service_1 = require('../../../core/services/notification.service');
var membership_service_1 = require('../../../modules/account/services/membership.service');
var ProjectDetailComponent = (function () {
    function ProjectDetailComponent(projectService, utilityService, notificationService, membershipService) {
        this.projectService = projectService;
        this.utilityService = utilityService;
        this.notificationService = notificationService;
        this.membershipService = membershipService;
    }
    ProjectDetailComponent.prototype.ngOnInit = function () {
        /*
        this.route.params
            .switchMap((params: Params) => this.projectService.getBySlug(+params['slug']))
            .subscribe(project => this.project = project);*/
    };
    ProjectDetailComponent = __decorate([
        core_1.Component({
            selector: 'am-project',
            templateUrl: './app/modules/projects/components/projectDetail.component.html'
        }), 
        __metadata('design:paramtypes', [data_service_1.DataService, utility_service_1.UtilityService, notification_service_1.NotificationService, membership_service_1.MembershipService])
    ], ProjectDetailComponent);
    return ProjectDetailComponent;
}());
exports.ProjectDetailComponent = ProjectDetailComponent;
