import { Component, OnInit, Input } from '@angular/core';
import { Project } from '../../modules/projects/domain/project';

@Component({
    selector: 'am-sidebar',
    templateUrl: './app/components/sidebar/sidebar.component.html'
})
export class SidebarComponent implements OnInit {
    
    @Input() 
    private _project: Project;

    constructor() { }

    ngOnInit() {

     }
}