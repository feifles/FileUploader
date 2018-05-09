import { Component, OnInit } from '@angular/core';
import { Group } from '../../Models/group';
import { GroupService } from '../../services/group.service';

@Component({
    selector: 'group-list',
    templateUrl: './group-list.component.html',
    styleUrls: ['./group-list.component.css']
})
/** group-list component*/
export class GroupListComponent implements OnInit {

    groups: Group[];

    /** group-list ctor */
    constructor(private groupService: GroupService) {
        this.groups = [];
    }

    ngOnInit() {
        this.groupService.getGroups(40)
            .subscribe(groups => this.groups = groups);
    }
}