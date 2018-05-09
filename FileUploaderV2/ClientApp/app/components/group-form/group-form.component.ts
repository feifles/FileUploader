import * as _ from 'underscore';
import { Component, OnInit, group } from '@angular/core';
import { GroupService } from '../../services/group.service';
import { ToastyService } from 'ng2-toasty';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/Observable/forkJoin';
import { SaveGroup } from '../../Models/saveGroup';
import { Group } from '../../Models/group';
import { KeyValuePair } from '../../Models/KeyValuePair';

@Component({
    selector: 'group-form',
    templateUrl: './group-form.component.html',
    styleUrls: ['./group-form.component.css']
})
/** group-form component*/
export class GroupFormComponent implements OnInit{
    /** group-form ctor */

    name: string;
    companies: any[];
    dbConfigs: any[];
    users: KeyValuePair[];
    group: SaveGroup = {
        id: 0,
        name: "",
        companyId: 0,
        dbConfigId: 0,
        dataFileTemplates: [],
        isActive: false,
        appUsers: []
    };

    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private groupService: GroupService,
        private toastyService: ToastyService) {

        this.name = "";
        this.companies = [];
        this.dbConfigs = [];
        this.users = [];

        route.params.subscribe(p => {
            this.group.id = +p['id'];
        });
    }

    ngOnInit() {

        var sources = [
            this.groupService.getCompanies()
        ];

        if (this.group.id) {
            sources.push(this.groupService.getGroup(this.group.id));
        }

        Observable.forkJoin(sources).subscribe(data => {
            this.companies = data[0];
            if (this.group.id) {
                this.setGroup(data[1]);
                this.populateAppUsers();
                this.populatedbConfig();
            }
            },
                err => {
                    if (err.status == 404)
                        this.router.navigate(['/not-found']);
            });
    }

    private setGroup(g: Group) {
        this.group.id = g.id;
        this.group.name = g.name;
        this.group.companyId = g.company.id;
        this.group.dbConfigId = g.dbConfig.id;
        this.group.dataFileTemplates = g.dataFileTemplates;
        this.group.isActive = g.isActive;
        this.group.appUsers = _.pluck(g.appUsers, 'id');

    }

    onCompanyChange() {

        this.group.appUsers = [];
        this.group.dbConfigId = 0;


        if (this.group.companyId === 0) {

            delete this.users;
            delete this.dbConfigs;
        }
        else {
            this.populateAppUsers();
            this.populatedbConfig();
        }
    }

    private populatedbConfig() {
        this.groupService
            .getDbConfigs(this.group.companyId)
            .subscribe(dbConfigs => this.dbConfigs = dbConfigs);
    }

    private populateAppUsers() {
        this.groupService
            .getAppUsers(this.group.companyId)
            .subscribe(appUsers => this.users = appUsers);
    }

    onUserToggle(userId: number, $event: { target: { checked: any; }; }) {

        if ($event.target.checked)
            this.group.appUsers.push(userId);
        else {
            var index = this.group.appUsers.indexOf(userId);
            this.group.appUsers.splice(index, 1);
        }
    }

    submit() {
        if (this.group.id) {
            this.groupService.update(this.group)
                .subscribe(x => {
                    this.toastyService.success({
                        title: 'Sucesso',
                        msg: 'O grupo foi atualizado com sucesso.',
                        theme: 'bootstrap',
                        showClose: true,
                        timeout: 5000
                    });
                });
        }
        else {
            this.groupService.create(this.group)
                .subscribe(x =>
                    console.log(x));
        }

    }

    delete() {
        if (confirm('Tem certeza que deseja remover este grupo?')) {
            this.groupService.delete(this.group.id)
                .subscribe(x => {
                    this.router.navigate(['/home']);
                });
        }
    }
}