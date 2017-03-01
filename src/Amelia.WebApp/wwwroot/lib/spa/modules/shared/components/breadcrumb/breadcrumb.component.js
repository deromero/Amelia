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
var membership_service_1 = require('../../../../modules/account/services/membership.service');
var BreadcrumbComponent = (function () {
    function BreadcrumbComponent(membershipService, location, route, router) {
        this.membershipService = membershipService;
        this.location = location;
        this.route = route;
        this.router = router;
        this.breadcrumbs = [];
    }
    BreadcrumbComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.getCurrentRoute();
        this.router.events.filter(function (event) { return event instanceof router_1.NavigationEnd; }).subscribe(function (event) {
            //set breadcrumbs
            var root = _this.route.root;
            _this.breadcrumbs = _this.getBreadcrumbs(root);
        });
    };
    BreadcrumbComponent.prototype.getBreadcrumbs = function (route, url, breadcrumbs) {
        if (url === void 0) { url = ""; }
        if (breadcrumbs === void 0) { breadcrumbs = []; }
        var ROUTE_DATA_BREADCRUMB = "name";
        var children = route.children;
        if (children.length == 0) {
            return breadcrumbs;
        }
        for (var _i = 0, children_1 = children; _i < children_1.length; _i++) {
            var child = children_1[_i];
            if (child.outlet !== router_1.PRIMARY_OUTLET) {
                continue;
            }
            if (!child.snapshot.data.hasOwnProperty(ROUTE_DATA_BREADCRUMB)) {
                continue;
            }
            var routeUrl = child.snapshot.url.map(function (segment) { return segment.path; }).join("/");
            url += '/' + routeUrl;
            var breadcrumb = {
                label: child.snapshot.data[ROUTE_DATA_BREADCRUMB],
                params: child.snapshot.params,
                url: url
            };
            breadcrumbs.push(breadcrumb);
            return this.getBreadcrumbs(child, url, breadcrumbs);
        }
    };
    BreadcrumbComponent.prototype.getCurrentRoute = function () {
        var _this = this;
        this.router.events
            .filter(function (event) { return event instanceof router_1.NavigationEnd; })
            .subscribe(function (event) {
            var currentRoute = _this.route.root;
            while (currentRoute.children[0] !== undefined) {
                currentRoute = currentRoute.children[0];
            }
            _this.thisPage = currentRoute.snapshot.data;
        });
    };
    ;
    BreadcrumbComponent = __decorate([
        core_1.Component({
            selector: 'am-breadcrumb',
            templateUrl: './app/modules/shared/components/breadcrumb/breadcrumb.component.html'
        }), 
        __metadata('design:paramtypes', [membership_service_1.MembershipService, common_1.Location, router_1.ActivatedRoute, router_1.Router])
    ], BreadcrumbComponent);
    return BreadcrumbComponent;
}());
exports.BreadcrumbComponent = BreadcrumbComponent;
