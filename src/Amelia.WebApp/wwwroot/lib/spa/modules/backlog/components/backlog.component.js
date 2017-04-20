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
var project_service_1 = require('../../projects/services/project.service');
var utility_service_1 = require('../../../core/services/utility.service');
var notification_service_1 = require('../../../core/services/notification.service');
var BacklogComponent = (function () {
    function BacklogComponent(projectService, utilityService, notificationService, route, router) {
        this.projectService = projectService;
        this.utilityService = utilityService;
        this.notificationService = notificationService;
        this.route = route;
        this.router = router;
    }
    BacklogComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.sub = this.route.params.subscribe(function (params) {
            _this._projectSlug = params["slug"];
            _this.getProject();
        });
    };
    BacklogComponent.prototype.getProject = function () {
        var _this = this;
        this.projectService.getBySlug(this._projectSlug)
            .subscribe(function (res) {
            var data = res.json();
            _this._project = data;
            //TODO: GetBacklog
        }, function (error) {
            _this.notificationService.printErrorMessage(error);
        });
    };
    BacklogComponent = __decorate([
        core_1.Component({
            selector: 'backlog',
            templateUrl: './app/modules/backlog/components/backlog.component.html'
        }), 
        __metadata('design:paramtypes', [project_service_1.ProjectService, utility_service_1.UtilityService, notification_service_1.NotificationService, router_1.ActivatedRoute, router_1.Router])
    ], BacklogComponent);
    return BacklogComponent;
}());
exports.BacklogComponent = BacklogComponent;
