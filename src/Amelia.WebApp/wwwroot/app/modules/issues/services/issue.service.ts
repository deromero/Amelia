import { Http, Response, Request } from '@angular/http';
import { Injectable } from '@angular/core';
import { DataService } from '../../../core/services/data.service';
//import { ProjectForm } from '../domain/projectForm';
import { Issue } from '../domain/issue';

@Injectable()
export class IssueService {

    private _issueGetListAPI: string = 'api/tasks/';

    constructor(public dataService: DataService) { }

    public getByProject(projectId: number, page: number, pageSize: number) {
        this.dataService.set(this._issueGetListAPI, pageSize);
        return this.dataService.getByParent(projectId, page);
    }

}