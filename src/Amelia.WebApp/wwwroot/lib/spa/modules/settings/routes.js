"use strict";
var router_1 = require('@angular/router');
var settings_component_1 = require('./components/settings.component');
exports.settingsRoutes = [
    { path: 'settings', component: settings_component_1.SettingsComponent, data: { name: 'Settings' } }
];
exports.settingsRouting = router_1.RouterModule.forChild(exports.settingsRoutes);
