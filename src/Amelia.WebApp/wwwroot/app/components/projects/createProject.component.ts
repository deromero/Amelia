import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProjectForm } from '../../core/domain/projectForm';
import { OperationResult } from '../../core/domain/operationResult';
import { NotificationService } from '../../core/services/notification.service';
import { ProjectService } from '../../core/services/project.service';

@Component({
    selector: 'createProject',
    providers: [ProjectService, NotificationService],
    templateUrl: './app/components/projects/createProject.component.html'
})
export class CreateProjectComponent implements OnInit {

    private _newProject: ProjectForm;

    constructor(public projectService: ProjectService,
        public notificationService: NotificationService,
        public router: Router) { }

    ngOnInit() {
        this._newProject = new ProjectForm(0, '', '', false, 0, 0);
    }

    create(): void {
        var result: OperationResult = new OperationResult(false, '');
        this.projectService.create(this._newProject)
            .subscribe(res => {
                result.Succeeded = res.Succeeded;
                result.Message = res.Message;
            },
            error => console.error('Error: ' + error),
            () => {
                if (result.Succeeded) {
                    this.notificationService.printSuccessMessage(result.Message)
                    this.router.navigate(['projects']);
                }
                else{
                    this.notificationService.printErrorMessage(result.Message);
                }
            });
    }
};