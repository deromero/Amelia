"use strict";
var router_1 = require('@angular/router');
var admin_component_1 = require('./components/admin.component');
exports.adminRoutes = [
    { path: 'projects/:slug/admin', component: admin_component_1.AdminComponent, data: { name: 'Admin' } }
];
exports.adminRouting = router_1.RouterModule.forChild(exports.adminRoutes);
