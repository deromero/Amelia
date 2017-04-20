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
var paginated_1 = require('../../../core/common/paginated');
var sprint_service_1 = require('../services/sprint.service');
var utility_service_1 = require('../../../core/services/utility.service');
var notification_service_1 = require('../../../core/services/notification.service');
var BehaviorSubject_1 = require('rxjs/BehaviorSubject');
var SprintsComponent = (function (_super) {
    __extends(SprintsComponent, _super);
    function SprintsComponent(sprintService, utilityService, notificationService) {
        _super.call(this, 0, 0, 0);
        this.sprintService = sprintService;
        this.utilityService = utilityService;
        this.notificationService = notificationService;
        this._isEmpty = true;
        this._project = new BehaviorSubject_1.BehaviorSubject(null);
    }
    Object.defineProperty(SprintsComponent.prototype, "project", {
        get: function () { return this._project.getValue(); },
        set: function (value) { this._project.next(value); },
        enumerable: true,
        configurable: true
    });
    SprintsComponent.prototype.ngOnInit = function () {
        var _this = this;
        this._project
            .subscribe(function (x) {
            if (_this.project) {
                console.log('id > ' + _this.project.Id);
                _this.getSprints(_this.project.Id);
            }
        });
    };
    SprintsComponent.prototype.getSprints = function (projectId) {
        var _this = this;
        this.sprintService.getByProject(projectId, 0, 10)
            .subscribe(function (res) {
            var data = res.json();
            _this._sprints = data.Items;
            _this._page = data.Page;
            _this._pagesCount = data.TotalPages;
            _this._totalCount = data.TotalCount;
            _this._isEmpty = _this._totalCount <= 0;
        }, function (error) {
            if (error.status == 401 || error.status == 403) {
                _this.notificationService.printErrorMessage("Authentication required");
                _this.utilityService.navigateToSignIn();
            }
            else {
                _this.notificationService.printErrorMessage(error);
            }
        });
    };
    __decorate([
        core_1.Input(), 
        __metadata('design:type', Object), 
        __metadata('design:paramtypes', [Object])
    ], SprintsComponent.prototype, "project", null);
    SprintsComponent = __decorate([
        core_1.Component({
            selector: 'sprints',
            templateUrl: './app/modules/backlog/components/sprints.component.html'
        }), 
        __metadata('design:paramtypes', [sprint_service_1.SprintService, utility_service_1.UtilityService, notification_service_1.NotificationService])
    ], SprintsComponent);
    return SprintsComponent;
}(paginated_1.Paginated));
exports.SprintsComponent = SprintsComponent;
