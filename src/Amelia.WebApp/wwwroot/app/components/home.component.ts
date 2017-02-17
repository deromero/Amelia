import {Component, OnInit} from '@angular/core';
import { NotificationService } from '../core/services/notification.service';

@Component({
    selector: 'home',
    templateUrl: './app/components/home.component.html'
})
export class HomeComponent implements OnInit {

    constructor(public notificationService: NotificationService) {}

    ngOnInit(){
        this.notificationService.printSuccessMessage("ingreso");
    }
}