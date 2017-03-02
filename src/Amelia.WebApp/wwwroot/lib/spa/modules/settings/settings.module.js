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
var settings_component_1 = require('./components/settings.component');
var data_service_1 = require('../../core/services/data.service');
var notification_service_1 = require('../../core/services/notification.service');
var routes_1 = require('./routes');
var SettingsModule = (function () {
    function SettingsModule() {
    }
    SettingsModule = __decorate([
        core_1.NgModule({
            imports: [
                common_1.CommonModule,
                forms_1.FormsModule,
                shared_module_1.SharedModule,
                routes_1.settingsRouting
            ],
            declarations: [
                settings_component_1.SettingsComponent
            ],
            providers: [
                data_service_1.DataService,
                notification_service_1.NotificationService
            ]
        }), 
        __metadata('design:paramtypes', [])
    ], SettingsModule);
    return SettingsModule;
}());
exports.SettingsModule = SettingsModule;