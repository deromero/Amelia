/// <reference path="../../../../../../typings/globals/es6-shim/index.d.ts" />
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
var common_1 = require('@angular/common');
var router_1 = require('@angular/router');
require('rxjs/add/operator/map');
require('rxjs/add/operator/filter');
var core_2 = require('@angular/core');
core_2.enableProdMode();
var notification_service_1 = require('../../../../core/services/notification.service');
var projectForm_1 = require('../../../projects/domain/projectForm');
var project_service_1 = require('../../../projects/services/project.service');
var EditComponent = (function () {
    function EditComponent(projectService, notificationService, location, route, router) {
        this.projectService = projectService;
        this.notificationService = notificationService;
        this.location = location;
        this.route = route;
        this.router = router;
    }
    EditComponent.prototype.ngOnInit = function () {
        var _this = this;
        this._projectForm = new projectForm_1.ProjectForm(0, '', '', false, 1, 0);
        this.router.events
            .filter(function (event) { return event instanceof router_1.NavigationEnd; })
            .subscribe(function (event) {
            var currentRoute = _this.route.root;
            while (currentRoute.children[0] !== undefined) {
                currentRoute = currentRoute.children[0];
            }
            currentRoute.params.subscribe(function (params) {
                _this._projectSlug = params['slug'];
                if (_this._projectSlug !== undefined) {
                    _this.getProject();
                }
                else {
                    _this._project = undefined;
                }
            });
        });
    };
    EditComponent.prototype.getProject = function () {
        var _this = this;
        this.projectService.getBySlug(this._projectSlug)
            .subscribe(function (res) {
            var data = res.json();
            _this._project = data;
            _this._projectForm = new projectForm_1.ProjectForm(data.Id, data.Name, data.Description, data.IsPrivate, data.ProjectType, data.OwnerId);
        }, function (error) {
            _this.notificationService.printErrorMessage(error);
        });
    };
    EditComponent = __decorate([
        core_1.Component({
            selector: 'edit-project',
            providers: [project_service_1.ProjectService],
            templateUrl: './app/modules/admin/components/project/edit.component.html'
        }), 
        __metadata('design:paramtypes', [project_service_1.ProjectService, notification_service_1.NotificationService, common_1.Location, router_1.ActivatedRoute, router_1.Router])
    ], EditComponent);
    return EditComponent;
}());
exports.EditComponent = EditComponent;
