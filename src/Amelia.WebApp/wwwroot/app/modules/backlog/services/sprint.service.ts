import { Http, Response, Request } from '@angular/http';
import { Injectable } from '@angular/core';
import { DataService } from '../../../core/services/data.service';
import { Sprint } from '../domain/sprint';

@Injectable()
export class SprintService {

    private _sprintsAPI: string = 'api/tasks/';

    constructor(public dataService: DataService) { }

    public getByProject(projectId: number, page: number, pageSize: number) {
        this.dataService.set(this._sprintsAPI, pageSize);
        return this.dataService.getByParent(projectId, page);
    }

}