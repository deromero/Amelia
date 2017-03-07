"use strict";
var router_1 = require('@angular/router');
var board_component_1 = require('./components/board.component');
exports.boardRoutes = [
    { path: 'projects/:slug/board', component: board_component_1.BoardComponent, data: { name: 'Kanban Board' } }
];
exports.boardRouting = router_1.RouterModule.forChild(exports.boardRoutes);
