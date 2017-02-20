
import { Component, OnInit } from '@angular/core';
import { Paginated } from '../../../core/common/paginated';
import { DataService } from '../../../core/services/data.service';
import { UtilityService } from '../../../core/services/utility.service';
import { NotificationService } from '../../../core/services/notification.service';

@Component({
    selector: 'settings',
    templateUrl: './app/modules/settings/components/settings.component.html'
})
export class SettingsComponent extends Paginated implements OnInit {


    constructor(public settingsService: DataService,
        public utilityService: UtilityService,
        public notificationService: NotificationService) {
        super(0, 0, 0);
    }

    ngOnInit() {
    }


}