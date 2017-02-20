/// <reference path="../../../../../../typings/globals/es6-shim/index.d.ts" />

import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import 'rxjs/add/operator/map';
import { enableProdMode } from '@angular/core';

enableProdMode();
import { MembershipService } from '../../../../modules/account/services/membership.service';
import { User } from '../../../../modules/account/domain/user';

@Component({
    selector: 'am-breadcrumb',
    templateUrl: './app/modules/shared/components/breadcrumb/breadcrumb.component.html'
})
export class BreadcrumbComponent implements OnInit {

    constructor(public membershipService: MembershipService,
        public location: Location) { }

    ngOnInit() { }


}