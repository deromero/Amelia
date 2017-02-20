/// <reference path="../../typings/globals/es6-shim/index.d.ts" />
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
var membership_service_1 = require('./modules/account/services/membership.service');
var AppComponent = (function () {
    function AppComponent(membershipService, location, route, router) {
        this.membershipService = membershipService;
        this.location = location;
        this.route = route;
        this.router = router;
    }
    AppComponent.prototype.ngOnInit = function () {
        this.getCurrentRoute();
    };
    AppComponent.prototype.isUserLoggedIn = function () {
        return this.membershipService.isUserAuthenticated();
    };
    AppComponent.prototype.getUserName = function () {
        if (this.isUserLoggedIn()) {
            var _user = this.membershipService.getLoggedInUser();
            return _user.Username;
        }
        else
            return 'Account';
    };
    AppComponent.prototype.logout = function () {
        this.membershipService.logout()
            .subscribe(function (res) {
            localStorage.removeItem('user');
        }, function (error) { return console.error('Error: ' + error); }, function () { });
    };
    AppComponent.prototype.getCurrentRoute = function () {
        var _this = this;
        this.router.events
            .filter(function (event) { return event instanceof router_1.NavigationEnd; })
            .subscribe(function (event) {
            var currentRoute = _this.route.root;
            while (currentRoute.children[0] !== undefined) {
                currentRoute = currentRoute.children[0];
            }
            console.log(currentRoute.snapshot.data);
        });
    };
    AppComponent = __decorate([
        core_1.Component({
            selector: 'amelia-app',
            templateUrl: './app/app.component.html'
        }), 
        __metadata('design:paramtypes', [membership_service_1.MembershipService, common_1.Location, router_1.ActivatedRoute, router_1.Router])
    ], AppComponent);
    return AppComponent;
}());
exports.AppComponent = AppComponent;
;
