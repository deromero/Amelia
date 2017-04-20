import { Component, OnInit, Input } from '@angular/core';

import { Paginated } from '../../../core/common/paginated';
import { Project } from '../../../modules/projects/domain/project';
import { Sprint } from './../domain/sprint'
import { SprintService } from '../services/sprint.service';
import { UtilityService } from '../../../core/services/utility.service';
import { NotificationService } from '../../../core/services/notification.service';

import { Subscription } from 'rxjs/Subscription';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';

@Component({
    selector: 'sprints',
    templateUrl: './app/modules/backlog/components/sprints.component.html'
})
export class SprintsComponent extends Paginated implements OnInit {

    private _sprints: Array<Sprint>;
    private _isEmpty: boolean = true;

    private _project = new BehaviorSubject<Project>(null);
    private _theProject: Project;

    @Input()
    set project(value) { this._project.next(value); }

    get project(): Project { return this._project.getValue(); }

    constructor(public sprintService: SprintService,
        public utilityService: UtilityService,
        public notificationService: NotificationService) {
        super(0, 0, 0)
    }

    ngOnInit() {

        this._project
            .subscribe(x => {
                if (this.project) {
                    console.log('id > ' + this.project.Id);
                    this.getSprints(this.project.Id);
                }

            });
    }

    getSprints(projectId: number): void {

        this.sprintService.getByProject(projectId, 0, 10)
            .subscribe(res => {

                var data: any = res.json();
                this._sprints = data.Items;
                this._page = data.Page;
                this._pagesCount = data.TotalPages;
                this._totalCount = data.TotalCount;

                this._isEmpty = this._totalCount <= 0;

            }, error => {
                if (error.status == 401 || error.status == 403) {
                    this.notificationService.printErrorMessage("Authentication required");
                    this.utilityService.navigateToSignIn();
                } else {
                    this.notificationService.printErrorMessage(error);
                }
            });
    }
}