import { Component, OnInit } from '@angular/core';
import { GroupService } from '../../services/group.service';

@Component({
    selector: 'group-form',
    templateUrl: './group-form.component.html',
    styleUrls: ['./group-form.component.css']
})
/** group-form component*/
export class GroupFormComponent implements OnInit{
    /** group-form ctor */

    makes: any[];
    models: any[];
    appUsers: any[];
    vehicle: any = {};

    constructor(private groupService: GroupService) { }

    ngOnInit() {
        this.groupService.getAppUsers().subscribe(appUsers =>
            this.appUsers = appUsers);
    }
}