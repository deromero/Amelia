import { Http, Response, Request } from '@angular/http';
import { Injectable } from '@angular/core';
import { DataService } from './data.service';
import { ProjectForm } from '../../modules/projects/domain/projectForm';
import { Project } from '../domain/project';

@Injectable()
export class ProjectService {

    private _projectCreateAPI: string = 'api/projects/create';

    constructor(public dataService: DataService) { }

    create(newProject: ProjectForm){
        this.dataService.set(this._projectCreateAPI);
        return this.dataService.post(JSON.stringify(newProject));
    }
}