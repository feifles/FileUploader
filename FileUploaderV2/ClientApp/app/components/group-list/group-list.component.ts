import { Component, OnInit } from '@angular/core';
import { Group } from '../../Models/group';
import { KeyValuePair } from '../../Models/KeyValuePair';
import 'rxjs/add/Observable/forkJoin';
import { ActivatedRoute, Router } from '@angular/router';
import { GroupService } from '../../services/group.service';
import { ToastyService } from 'ng2-toasty';
import { Observable } from 'rxjs/Observable';

@Component({
    selector: 'group-list',
    templateUrl: './group-list.component.html',
    styleUrls: ['./group-list.component.css']
})
/** group-list component*/
export class GroupListComponent implements OnInit {

    groups: Group[];
    allGroups: Group[];
    query: any = {
        companyId: 0,
        dbConfigId: 0
    };
    companies: KeyValuePair[];
    dbConfigs: KeyValuePair[];

    /** group-list ctor */
    constructor(private route: ActivatedRoute,
            private router: Router,
            private groupService: GroupService,
            private toastyService: ToastyService) {

        this.groups = [];
        this.allGroups = [];
        this.companies = [];
        this.dbConfigs = [];
    }

    ngOnInit() {

        var sources = [
            this.groupService.getCompanies(),
            this.groupService.getDbConfigs()
        ];

        Observable.forkJoin(sources).subscribe(data => {
            this.companies = data[0];
            this.dbConfigs = data[1];
        },
            err => {
                if (err.status == 404)
                    this.router.navigate(['/not-found']);
            });

        this.populateGroups();

    }

    private populateGroups() {
        this.groupService.getGroups(this.query)
            //Filter on the server
            .subscribe(groups => this.groups = groups);

        //Filter on the client
        //.subscribe(groups => this.groups = this.allGroups = groups);
    }

    onFilterChange() {

        this.populateGroups();

        //Filter on the client

        //var groups = this.allGroups;

        //if (this.filter.companyId)
        //    groups = groups.filter(g => g.company.id == this.filter.companyId);

        //if (this.filter.dbConfigId)
        //    groups = groups.filter(g => g.dbConfig.id == this.filter.dbConfigId);

        //this.groups = groups;

        //End Filter on the client
    }

    resetFilter() {
        this.query = {};
        this.onFilterChange();
    }

    sortBy(columnName: string) {
        if (this.query.sortBy === columnName) {
            this.query.isSortAscending = false;
        } else {
            this.query.sortBy = columnName;
            this.query.isSortAscending = true;
        }

        this.populateGroups();
    }
}