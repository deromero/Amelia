
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Project } from '../../../modules/projects/domain/project';
import { ProjectService } from '../../projects/services/project.service';
import { Issue } from '../../../modules/issues/domain/issue';
import { IssueService } from '../../issues/services/issue.service';

import { Paginated } from '../../../core/common/paginated';
import { DataService } from '../../../core/services/data.service';
import { UtilityService } from '../../../core/services/utility.service';
import { NotificationService } from '../../../core/services/notification.service';
import { Subscription } from 'rxjs/Subscription';

@Component({
    selector: 'issues',
    templateUrl: './app/modules/issues/components/issues.component.html'
})
export class IssuesComponent extends Paginated implements OnInit {

    private _project: Project;
    private _projectSlug: string;
    private _issues: Array<Issue>;
    private sub: Subscription;
    private _isEmpty: boolean = true;

    constructor(public projectService: ProjectService,
        public issueService: IssueService,
        public utilityService: UtilityService,
        public notificationService: NotificationService,
        private route: ActivatedRoute,
        private router: Router) {
        super(0, 0, 0);
    }

    ngOnInit(): void {

        this.sub = this.route.params.subscribe(params => {
            this._projectSlug = params['slug'];
            this.getProject();
        });
    }

    getProject(): void {
        this.projectService.getBySlug(this._projectSlug)
            .subscribe(res => {
                var data: any = res.json();
                this._project = data;
                this.getIssues(this._project.Id);
            }, error => {
                this.notificationService.printErrorMessage(error);
            });
    }

    getIssues(projectId: number): void {

        
        this.issueService.getByProject(projectId, this._page, 15)
            .subscribe(res => {

                var data: any = res.json();
                this._issues = data.Items;
                this._page = data.Page;
                this._pagesCount = data.TotalPages;
                this._totalCount = data.TotalCount;

                this._isEmpty = this._totalCount <=0;

            }, error => {
                if (error.status == 401 || error.status == 404) {
                    this.notificationService.printErrorMessage("Authentication required");
                    this.utilityService.navigateToSignIn();
                } else {
                    this.notificationService.printErrorMessage(error);
                }
            })

    }

    search(page): void {
        super.search(page);
        this.getIssues(this._project.Id);
    }
}