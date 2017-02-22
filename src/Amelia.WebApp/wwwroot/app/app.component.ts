/// <reference path="../../typings/globals/es6-shim/index.d.ts" />

import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { Router, ActivatedRoute, NavigationEnd } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/filter';
import { enableProdMode } from '@angular/core';

enableProdMode();
import { MembershipService } from './modules/account/services/membership.service';
import { User } from './modules/account/domain/user';

@Component({
    selector: 'amelia-app',
    templateUrl: './app/app.component.html'
})
export class AppComponent implements OnInit {

    constructor(
        public membershipService: MembershipService,
        public location: Location,
        private route: ActivatedRoute,
        private router: Router) { }

    ngOnInit() {
    }

    isUserLoggedIn(): boolean {
        return this.membershipService.isUserAuthenticated();
    }

    getUserName(): string {
        if (this.isUserLoggedIn()) {
            var _user = this.membershipService.getLoggedInUser();
            return _user.Username;
        }
        else
            return 'Account';
    }

    logout(): void {
        this.membershipService.logout()
            .subscribe(res => {
                localStorage.removeItem('user');
            },
            error => console.error('Error: ' + error),
            () => { });
    }

    
};