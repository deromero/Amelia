/// <reference path="../../../../../../typings/globals/es6-shim/index.d.ts" />

import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import 'rxjs/add/operator/map';
import { enableProdMode } from '@angular/core';

enableProdMode();
import { MembershipService } from '../../../../modules/account/services/membership.service';
import { User } from '../../../../modules/account/domain/user';
import { UtilityService } from '../../../../core/services/utility.service';


@Component({
    selector: 'am-header',
    templateUrl: './app/modules/shared/components/header/header.component.html'
})
export class HeaderComponent implements OnInit {

    constructor(public membershipService: MembershipService,
        public utilityService: UtilityService,
        public location: Location) { }

    ngOnInit() { }

    isUserLoggedIn(): boolean {
        return this.membershipService.isUserAuthenticated();
    }

    getUserName(): string {
        if (this.isUserLoggedIn()) {
            var _user = this.membershipService.getLoggedInUser();
            return _user.Username;
        }
        else
            return 'Login';
    }

    logout(): void {
        this.membershipService.logout()
            .subscribe(res => {
                localStorage.removeItem('user');
                this.utilityService.navigateToHome();
            },
            error => console.error('Error: ' + error),
            () => { });
    }

}