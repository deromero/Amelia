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
var router_1 = require('@angular/router');
var project_service_1 = require('../services/project.service');
var notification_service_1 = require('../../../core/services/notification.service');
var ProjectDetailComponent = (function () {
    function ProjectDetailComponent(projectService, notificationService, route, router) {
        this.projectService = projectService;
        this.notificationService = notificationService;
        this.route = route;
        this.router = router;
    }
    ProjectDetailComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.sub = this.route.params.subscribe(function (params) {
            _this._projectSlug = params['slug'];
            _this.getProject();
        });
    };
    ProjectDetailComponent.prototype.getProject = function () {
        var _this = this;
        this.projectService.getBySlug(this._projectSlug)
            .subscribe(function (res) {
            var data = res.json();
            _this._project = data;
        }, function (error) {
            _this.notificationService.printErrorMessage(error);
        });
    };
    ProjectDetailComponent = __decorate([
        core_1.Component({
            selector: 'project-Detail',
            providers: [project_service_1.ProjectService, notification_service_1.NotificationService],
            templateUrl: './app/modules/projects/components/projectDetail.component.html'
        }), 
        __metadata('design:paramtypes', [project_service_1.ProjectService, notification_service_1.NotificationService, router_1.ActivatedRoute, router_1.Router])
    ], ProjectDetailComponent);
    return ProjectDetailComponent;
}());
exports.ProjectDetailComponent = ProjectDetailComponent;
;
