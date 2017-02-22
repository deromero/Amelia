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
var utility_service_1 = require('../core/services/utility.service');
var membership_service_1 = require('../modules/account/services/membership.service');
var notification_service_1 = require('../core/services/notification.service');
var HomeComponent = (function () {
    function HomeComponent(membershipService, notificationService, utilityService, location) {
        this.membershipService = membershipService;
        this.notificationService = notificationService;
        this.utilityService = utilityService;
        this.location = location;
    }
    HomeComponent.prototype.ngOnInit = function () {
        if (this.isUserLoggedIn()) {
            this.utilityService.navigate("dashboard");
        }
        else {
            this.utilityService.navigateToSignIn();
        }
    };
    HomeComponent.prototype.isUserLoggedIn = function () {
        return this.membershipService.isUserAuthenticated();
    };
    HomeComponent = __decorate([
        core_1.Component({
            selector: 'home',
            templateUrl: './app/components/home.component.html'
        }), 
        __metadata('design:paramtypes', [membership_service_1.MembershipService, notification_service_1.NotificationService, utility_service_1.UtilityService, common_1.Location])
    ], HomeComponent);
    return HomeComponent;
}());
exports.HomeComponent = HomeComponent;
