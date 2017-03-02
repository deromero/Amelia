"use strict";
var router_1 = require('@angular/router');
var projects_component_1 = require('./components/projects.component');
var projectDetail_component_1 = require('./components/projectDetail.component');
var createProject_component_1 = require('./components/createProject.component');
exports.projectRoutes = [
    { path: 'projects', component: projects_component_1.ProjectsComponent, data: { name: 'Projects' } },
    { path: 'projects/new', component: createProject_component_1.CreateProjectComponent, data: { name: 'Create a New Project' } },
    { path: 'projects/:slug/show', component: projectDetail_component_1.ProjectDetailComponent, data: { name: 'Project Details' } }
];
exports.projectRouting = router_1.RouterModule.forChild(exports.projectRoutes);
