import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { Location, LocationStrategy, HashLocationStrategy } from '@angular/common';
import { Headers, RequestOptions, BaseRequestOptions } from '@angular/http';

import { AccountModule } from './modules/account/account.module';
import { SharedModule } from './modules/shared/shared.module';
import { ProjectModule } from './modules/projects/project.module';
import { BacklogModule } from './modules/backlog/backlog.module';
import { SettingsModule } from './modules/settings/settings.module';

import { AppComponent } from './app.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { HomeComponent } from './components/home.component';
import { routing } from './routes';

import { DataService } from './core/services/data.service';
import { MembershipService } from './modules/account/services/membership.service';
import { UtilityService } from './core/services/utility.service';
import { NotificationService } from './core/services/notification.service';

class AppBaseRequestOptions extends BaseRequestOptions {
    headers: Headers = new Headers();

    constructor() {
        super();
        this.headers.append('Content-Type', 'application/json');
        this.body = '';
    }
}

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        routing,
        AccountModule,
        SharedModule,
        SettingsModule,
        ProjectModule,
        BacklogModule
    ],
    declarations: [
        AppComponent, 
        DashboardComponent,
        HomeComponent       
        ],
    providers: [
        DataService, 
        MembershipService, 
        UtilityService, 
        NotificationService,
        { provide: LocationStrategy, useClass: HashLocationStrategy },
        { provide: RequestOptions, useClass: AppBaseRequestOptions }],
    bootstrap: [AppComponent]
})
export class AppModule { }