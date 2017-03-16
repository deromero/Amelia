import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from '../domain/user';
import { UserView } from '../domain/userView';
import { OperationResult } from '../../../core/domain/operationResult';
import { MembershipService } from '../services/membership.service';
import { NotificationService } from '../../../core/services/notification.service';

@Component({
    selector: 'albums',
    templateUrl: './app/modules/account/components/login.component.html'
})
export class LoginComponent implements OnInit {
    private _user: User;
    private _userView: any;

    constructor(public membershipService: MembershipService,
                public notificationService: NotificationService,
                public router: Router) { }

    ngOnInit() {
        this._user = new User('', '');
    }

    login(): void {
        var _authenticationResult: OperationResult = new OperationResult(false, '');

        this.membershipService.login(this._user)
            .subscribe(res => {
                _authenticationResult.Succeeded = res.Succeeded;
                _authenticationResult.Message = res.Message;
                this._userView = res.ReturnValue;
            },
            error => console.error('Error: ' + error),
            () => {
                if (_authenticationResult.Succeeded) {
                    this.notificationService.printSuccessMessage('Welcome back ' + this._user.Username + '!');
                    localStorage.setItem('userView',JSON.stringify(this._userView));
                    this.router.navigate(['home']);
                }
                else {
                    this.notificationService.printErrorMessage(_authenticationResult.Message);
                }
            });
    };
}