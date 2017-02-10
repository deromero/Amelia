import { Http, Response, Request } from '@angular/http';
import { Injectable } from '@angular/core';
import { DataService } from '../../../core/services/data.service';
import { ProjectForm } from '../domain/projectForm';
import { Project } from '../domain/project';

@Injectable()
export class ProjectService {

    private _projectCreateAPI: string = 'api/projects/create';
    private _projectGetBySlugAPI: string = 'api/projects/getBySlug?slug=';

    constructor(public dataService: DataService) { }

    create(newProject: ProjectForm){
        this.dataService.set(this._projectCreateAPI);
        return this.dataService.post(JSON.stringify(newProject));
    }

    public getBySlug(slug: string){
        this.dataService.set(this._projectGetBySlugAPI + slug);
        return this.dataService.get(0);
    }
}