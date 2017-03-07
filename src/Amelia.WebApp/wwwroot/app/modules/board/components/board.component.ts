
import { Component, OnInit } from '@angular/core';

import { Project } from '../../../modules/projects/domain/project';
import { Paginated } from '../../../core/common/paginated';
import { DataService } from '../../../core/services/data.service';
import { UtilityService } from '../../../core/services/utility.service';
import { NotificationService } from '../../../core/services/notification.service';

@Component({
    selector: 'backlog',
    templateUrl: './app/modules/board/components/board.component.html'
})
export class BoardComponent implements OnInit {

    constructor(public projectService: DataService,
        public utilityService: UtilityService,
        public notificationService: NotificationService) {
    }

    ngOnInit() {
    }

}