"use strict";
var router_1 = require('@angular/router');
var backlog_component_1 = require('./components/backlog.component');
exports.backlogRoutes = [
    { path: 'projects/:slug/backlog', component: backlog_component_1.BacklogComponent, data: { name: 'BackLog' } }
];
exports.backlogRouting = router_1.RouterModule.forChild(exports.backlogRoutes);
