"use strict";
var router_1 = require('@angular/router');
var projects_component_1 = require('./components/projects.component');
var projectDetail_component_1 = require('./components/projectDetail.component');
var createProject_component_1 = require('./components/createProject.component');
exports.projectRoutes = [
    {
        path: 'projects',
        component: projects_component_1.ProjectsComponent,
    },
    {
        path: 'projects/:slug',
        component: projectDetail_component_1.ProjectDetailComponent,
    },
    {
        path: 'projects/create',
        component: createProject_component_1.CreateProjectComponent
    }
];
exports.projectRouting = router_1.RouterModule.forChild(exports.projectRoutes);
