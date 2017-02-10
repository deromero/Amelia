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
var projectForm_1 = require('../domain/projectForm');
var operationResult_1 = require('../../../core/domain/operationResult');
var notification_service_1 = require('../../../core/services/notification.service');
var project_service_1 = require('../services/project.service');
var CreateProjectComponent = (function () {
    function CreateProjectComponent(projectService, notificationService, router) {
        this.projectService = projectService;
        this.notificationService = notificationService;
        this.router = router;
    }
    CreateProjectComponent.prototype.ngOnInit = function () {
        this._newProject = new projectForm_1.ProjectForm(0, '', '', false, 1, 0);
    };
    CreateProjectComponent.prototype.create = function () {
        var _this = this;
        var result = new operationResult_1.OperationResult(false, '');
        this.projectService.create(this._newProject)
            .subscribe(function (res) {
            result.Succeeded = res.Succeeded;
            result.Message = res.Message;
            result.Value = res.ReturnValue;
        }, function (error) { return console.error('Error: ' + error); }, function () {
            if (result.Succeeded) {
                _this.notificationService.printSuccessMessage(result.Message);
                _this.router.navigate(['project', result.Value.Slug]);
            }
            else {
                _this.notificationService.printErrorMessage(result.Message);
            }
        });
    };
    CreateProjectComponent = __decorate([
        core_1.Component({
            selector: 'createProject',
            providers: [project_service_1.ProjectService, notification_service_1.NotificationService],
            templateUrl: './app/modules/projects/components/createProject.component.html'
        }), 
        __metadata('design:paramtypes', [project_service_1.ProjectService, notification_service_1.NotificationService, router_1.Router])
    ], CreateProjectComponent);
    return CreateProjectComponent;
}());
exports.CreateProjectComponent = CreateProjectComponent;
;
