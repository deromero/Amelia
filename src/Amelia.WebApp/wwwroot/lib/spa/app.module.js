"use strict";
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
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
var platform_browser_1 = require('@angular/platform-browser');
var http_1 = require('@angular/http');
var forms_1 = require('@angular/forms');
var common_1 = require('@angular/common');
var http_2 = require('@angular/http');
var account_module_1 = require('./modules/account/account.module');
var shared_module_1 = require('./modules/shared/shared.module');
var project_module_1 = require('./modules/projects/project.module');
var backlog_module_1 = require('./modules/backlog/backlog.module');
var board_module_1 = require('./modules/board/board.module');
var issues_module_1 = require('./modules/issues/issues.module');
var team_module_1 = require('./modules/team/team.module');
var admin_module_1 = require('./modules/admin/admin.module');
var settings_module_1 = require('./modules/settings/settings.module');
var app_component_1 = require('./app.component');
var dashboard_component_1 = require('./components/dashboard/dashboard.component');
var home_component_1 = require('./components/home.component');
var routes_1 = require('./routes');
var data_service_1 = require('./core/services/data.service');
var membership_service_1 = require('./modules/account/services/membership.service');
var utility_service_1 = require('./core/services/utility.service');
var notification_service_1 = require('./core/services/notification.service');
var AppBaseRequestOptions = (function (_super) {
    __extends(AppBaseRequestOptions, _super);
    function AppBaseRequestOptions() {
        _super.call(this);
        this.headers = new http_2.Headers();
        this.headers.append('Content-Type', 'application/json');
        this.body = '';
    }
    return AppBaseRequestOptions;
}(http_2.BaseRequestOptions));
var AppModule = (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        core_1.NgModule({
            imports: [
                platform_browser_1.BrowserModule,
                forms_1.FormsModule,
                http_1.HttpModule,
                routes_1.routing,
                account_module_1.AccountModule,
                shared_module_1.SharedModule,
                settings_module_1.SettingsModule,
                project_module_1.ProjectModule,
                backlog_module_1.BacklogModule,
                board_module_1.BoardModule,
                issues_module_1.IssuesModule,
                team_module_1.TeamModule,
                admin_module_1.AdminModule
            ],
            declarations: [
                app_component_1.AppComponent,
                dashboard_component_1.DashboardComponent,
                home_component_1.HomeComponent
            ],
            providers: [
                data_service_1.DataService,
                membership_service_1.MembershipService,
                utility_service_1.UtilityService,
                notification_service_1.NotificationService,
                { provide: common_1.LocationStrategy, useClass: common_1.HashLocationStrategy },
                { provide: http_2.RequestOptions, useClass: AppBaseRequestOptions }],
            bootstrap: [app_component_1.AppComponent]
        }), 
        __metadata('design:paramtypes', [])
    ], AppModule);
    return AppModule;
}());
exports.AppModule = AppModule;
