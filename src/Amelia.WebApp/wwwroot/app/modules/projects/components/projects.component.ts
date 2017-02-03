
import { Component, OnInit } from '@angular/core';
import { Project } from '../../../core/domain/project';
import { Paginated } from '../../../core/common/paginated';
import { DataService } from '../../../core/services/data.service';
import { UtilityService } from '../../../core/services/utility.service';
import { NotificationService } from '../../../core/services/notification.service';

@Component({
    selector: 'projects',
    templateUrl: './app/modules/projects/components/projects.component.html'
})
export class ProjectsComponent extends Paginated implements OnInit {
    private _projectsAPI: string = 'api/projects/';
    private _projects: Array<Project>;

    constructor(public projectService: DataService,
        public utilityService: UtilityService,
        public notificationService: NotificationService) {
        super(0, 0, 0);
    }

    ngOnInit() {
        this.projectService.set(this._projectsAPI, 3);
        this.getProjects();
    }

    getProjects(): void {
        this.projectService.get(this._page)
            .subscribe(res => {
                var data: any = res.json();
                this._projects = data.items;
                this._page = data.page;
                this._pagesCount = data.totalPages;
                this._totalCount = data.totalCount;
            },
            error => {
                if (error.status == 401 || error.status == 404) {
                    this.notificationService.printErrorMessage("Authentication required");
                    this.utilityService.navigateToSignIn();
                }
            });
    }
}