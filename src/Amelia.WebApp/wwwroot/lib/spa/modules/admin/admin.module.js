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
var forms_1 = require('@angular/forms');
var common_1 = require('@angular/common');
var shared_module_1 = require('../../modules/shared/shared.module');
var data_service_1 = require('../../core/services/data.service');
var project_service_1 = require('../../modules/projects/services/project.service');
var notification_service_1 = require('../../core/services/notification.service');
var utility_service_1 = require('../../core/services/utility.service');
var admin_component_1 = require('./components/admin.component');
var adminBar_component_1 = require('./components/adminBar.component');
var edit_component_1 = require('./components/project/edit.component');
var routes_1 = require('./routes');
var AdminModule = (function () {
    function AdminModule() {
    }
    AdminModule = __decorate([
        core_1.NgModule({
            imports: [
                common_1.CommonModule,
                forms_1.FormsModule,
                routes_1.adminRouting,
                shared_module_1.SharedModule
            ],
            declarations: [
                admin_component_1.AdminComponent,
                adminBar_component_1.AdminBarComponent,
                edit_component_1.EditComponent
            ],
            providers: [
                data_service_1.DataService,
                project_service_1.ProjectService,
                notification_service_1.NotificationService,
                utility_service_1.UtilityService
            ]
        }), 
        __metadata('design:paramtypes', [])
    ], AdminModule);
    return AdminModule;
}());
exports.AdminModule = AdminModule;
