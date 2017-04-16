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
var router_1 = require('@angular/router');
var project_service_1 = require('../../projects/services/project.service');
var issue_service_1 = require('../../issues/services/issue.service');
var paginated_1 = require('../../../core/common/paginated');
var utility_service_1 = require('../../../core/services/utility.service');
var notification_service_1 = require('../../../core/services/notification.service');
var IssuesComponent = (function (_super) {
    __extends(IssuesComponent, _super);
    function IssuesComponent(projectService, issueService, utilityService, notificationService, route, router) {
        _super.call(this, 0, 0, 0);
        this.projectService = projectService;
        this.issueService = issueService;
        this.utilityService = utilityService;
        this.notificationService = notificationService;
        this.route = route;
        this.router = router;
        this._isEmpty = true;
    }
    IssuesComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.sub = this.route.params.subscribe(function (params) {
            _this._projectSlug = params['slug'];
            _this.getProject();
        });
    };
    IssuesComponent.prototype.getProject = function () {
        var _this = this;
        this.projectService.getBySlug(this._projectSlug)
            .subscribe(function (res) {
            var data = res.json();
            _this._project = data;
            _this.getIssues(_this._project.Id);
        }, function (error) {
            _this.notificationService.printErrorMessage(error);
        });
    };
    IssuesComponent.prototype.getIssues = function (projectId) {
        var _this = this;
        this.issueService.getByProject(projectId, this._page, 15)
            .subscribe(function (res) {
            var data = res.json();
            _this._issues = data.Items;
            _this._page = data.Page;
            _this._pagesCount = data.TotalPages;
            _this._totalCount = data.TotalCount;
            _this._isEmpty = _this._totalCount <= 0;
        }, function (error) {
            if (error.status == 401 || error.status == 404) {
                _this.notificationService.printErrorMessage("Authentication required");
                _this.utilityService.navigateToSignIn();
            }
            else {
                _this.notificationService.printErrorMessage(error);
            }
        });
    };
    IssuesComponent.prototype.search = function (page) {
        _super.prototype.search.call(this, page);
        this.getIssues(this._project.Id);
    };
    IssuesComponent = __decorate([
        core_1.Component({
            selector: 'issues',
            templateUrl: './app/modules/issues/components/issues.component.html'
        }), 
        __metadata('design:paramtypes', [project_service_1.ProjectService, issue_service_1.IssueService, utility_service_1.UtilityService, notification_service_1.NotificationService, router_1.ActivatedRoute, router_1.Router])
    ], IssuesComponent);
    return IssuesComponent;
}(paginated_1.Paginated));
exports.IssuesComponent = IssuesComponent;
