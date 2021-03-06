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
require('rxjs/add/operator/map');
var core_2 = require('@angular/core');
core_2.enableProdMode();
var membership_service_1 = require('../../../../modules/account/services/membership.service');
var utility_service_1 = require('../../../../core/services/utility.service');
var HeaderComponent = (function () {
    function HeaderComponent(membershipService, utilityService, location) {
        this.membershipService = membershipService;
        this.utilityService = utilityService;
        this.location = location;
    }
    HeaderComponent.prototype.ngOnInit = function () { };
    HeaderComponent.prototype.isUserLoggedIn = function () {
        return this.membershipService.isUserAuthenticated();
    };
    HeaderComponent.prototype.getUserName = function () {
        if (this.isUserLoggedIn()) {
            var _user = this.membershipService.getLoggedInUser();
            return _user.Username;
        }
        else
            return 'Login';
    };
    HeaderComponent.prototype.logout = function () {
        var _this = this;
        this.membershipService.logout()
            .subscribe(function (res) {
            localStorage.removeItem('user');
            _this.utilityService.navigateToHome();
        }, function (error) { return console.error('Error: ' + error); }, function () { });
    };
    HeaderComponent = __decorate([
        core_1.Component({
            selector: 'am-header',
            templateUrl: './app/modules/shared/components/header/header.component.html'
        }), 
        __metadata('design:paramtypes', [membership_service_1.MembershipService, utility_service_1.UtilityService, common_1.Location])
    ], HeaderComponent);
    return HeaderComponent;
}());
exports.HeaderComponent = HeaderComponent;
