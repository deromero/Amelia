"use strict";
var router_1 = require('@angular/router');
var team_component_1 = require('./components/team.component');
exports.teamRoutes = [
    { path: 'projects/:slug/team', component: team_component_1.TeamComponent, data: { name: 'Team' } }
];
exports.teamRouting = router_1.RouterModule.forChild(exports.teamRoutes);
