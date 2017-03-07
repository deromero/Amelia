"use strict";
var router_1 = require('@angular/router');
var issues_component_1 = require('./components/issues.component');
exports.issuesRoutes = [
    { path: 'projects/:slug/issues', component: issues_component_1.IssuesComponent, data: { name: 'Issues' } }
];
exports.issuesRouting = router_1.RouterModule.forChild(exports.issuesRoutes);
