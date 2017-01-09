"use strict";
var router_1 = require('@angular/router');
var projects_component_1 = require('./projects.component');
var createProject_component_1 = require('./createProject.component');
exports.projectRoutes = [
    {
        path: 'projects',
        component: projects_component_1.ProjectsComponent,
        children: [
            { path: '', component: projects_component_1.ProjectsComponent },
            { path: 'create', component: createProject_component_1.CreateProjectComponent }
        ]
    }
];
exports.projectRouting = router_1.RouterModule.forChild(exports.projectRoutes);
