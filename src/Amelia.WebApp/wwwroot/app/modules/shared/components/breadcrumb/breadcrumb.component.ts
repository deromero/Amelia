/// <reference path="../../../../../../typings/globals/es6-shim/index.d.ts" />

import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { Router, ActivatedRoute, NavigationEnd, Params, PRIMARY_OUTLET } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/filter';
import { enableProdMode } from '@angular/core';

enableProdMode();
import { MembershipService } from '../../../../modules/account/services/membership.service';
import { User } from '../../../../modules/account/domain/user';

interface IBreadcrumb {
    label: string;
    params: Params;
    url: string;
}

@Component({
    selector: 'am-breadcrumb',
    templateUrl: './app/modules/shared/components/breadcrumb/breadcrumb.component.html'
})
export class BreadcrumbComponent implements OnInit {

    public thisPage: any;
    public breadcrumbs: IBreadcrumb[];

    constructor(public membershipService: MembershipService,
        public location: Location,
        private route: ActivatedRoute,
        private router: Router) {
        this.breadcrumbs = [];
    }

    ngOnInit() {
        this.getCurrentRoute();
        this.router.events.filter(event => event instanceof NavigationEnd).subscribe(event => {
            //set breadcrumbs
            let root: ActivatedRoute = this.route.root;
            this.breadcrumbs = this.getBreadcrumbs(root);
        });
    }


    private getBreadcrumbs(route: ActivatedRoute,
        url: string = "", breadcrumbs: IBreadcrumb[] = []): IBreadcrumb[] {

        const ROUTE_DATA_BREADCRUMB: string = "name";
        let children: ActivatedRoute[] = route.children;
        if (children.length == 0) {
            return breadcrumbs;
        }

        for (let child of children) {
            if (child.outlet !== PRIMARY_OUTLET) {
                continue;
            }

            if (!child.snapshot.data.hasOwnProperty(ROUTE_DATA_BREADCRUMB)) {
                continue;
            }

            let routeUrl: string = child.snapshot.url.map(segment => segment.path).join("/");
            url += '/'+routeUrl;

            let breadcrumb: IBreadcrumb = {
                label: child.snapshot.data[ROUTE_DATA_BREADCRUMB],
                params: child.snapshot.params,
                url: url
            };

            breadcrumbs.push(breadcrumb);

            return this.getBreadcrumbs(child, url, breadcrumbs);
        }

    }

    getCurrentRoute(): void {
        this.router.events
            .filter(event => event instanceof NavigationEnd)
            .subscribe(event => {
                let currentRoute = this.route.root;
                while (currentRoute.children[0] !== undefined) {
                    currentRoute = currentRoute.children[0];
                }
                this.thisPage = currentRoute.snapshot.data;
            })
    };

}