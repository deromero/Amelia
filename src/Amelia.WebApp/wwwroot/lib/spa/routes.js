"use strict";
var router_1 = require('@angular/router');
var home_component_1 = require('./components/home.component');
var dashboard_component_1 = require('./components/dashboard/dashboard.component');
var appRoutes = [
    { path: '', redirectTo: '/home', pathMatch: 'full' },
    { path: 'home', component: home_component_1.HomeComponent, data: { name: 'Home' } },
    { path: 'dashboard', component: dashboard_component_1.DashboardComponent, data: { name: 'Dashboard' } }
];
exports.routing = router_1.RouterModule.forRoot(appRoutes);
