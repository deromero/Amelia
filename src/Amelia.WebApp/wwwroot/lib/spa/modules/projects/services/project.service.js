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
var data_service_1 = require('../../../core/services/data.service');
var ProjectService = (function () {
    function ProjectService(dataService) {
        this.dataService = dataService;
        this._projectCreateAPI = 'api/projects/create';
        this._projectGetBySlugAPI = 'api/projects/getBySlug?slug=';
    }
    ProjectService.prototype.create = function (newProject) {
        this.dataService.set(this._projectCreateAPI);
        return this.dataService.post(JSON.stringify(newProject));
    };
    ProjectService.prototype.getBySlug = function (slug) {
        this.dataService.set(this._projectGetBySlugAPI + slug);
        return this.dataService.get(0);
    };
    ProjectService = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [data_service_1.DataService])
    ], ProjectService);
    return ProjectService;
}());
exports.ProjectService = ProjectService;
