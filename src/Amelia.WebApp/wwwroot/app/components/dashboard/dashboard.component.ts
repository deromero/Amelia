/// <reference path="../../../../typings/globals/es6-shim/index.d.ts" />

import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import 'rxjs/add/operator/map';
import { enableProdMode } from '@angular/core';
enableProdMode();

import { SharedModule } from '../../modules/shared/shared.module'

import { MembershipService } from '../../modules/account/services/membership.service';
import { User } from '../../modules/account/domain/user';

@Component({
    selector: 'am-dashboard',
    templateUrl: './app/components/dashboard/dashboard.component.html'
})
export class DashboardComponent implements OnInit {

    constructor(public membershipService: MembershipService,
        public location: Location) { }

    ngOnInit() { }






}