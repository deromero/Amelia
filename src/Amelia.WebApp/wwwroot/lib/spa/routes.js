"use strict";
var router_1 = require('@angular/router');
var home_component_1 = require('./components/home.component');
var projects_component_1 = require('./components/projects/projects.component');
var appRoutes = [
    {
        path: '',
        redirectTo: '/home',
        pathMatch: 'full'
    },
    {
        path: 'home',
        component: home_component_1.HomeComponent
    },
    {
        path: 'projects',
        component: projects_component_1.ProjectsComponent
    }
];
exports.routing = router_1.RouterModule.forRoot(appRoutes);
