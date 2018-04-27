import { Component, OnInit } from '@angular/core';
import { GroupService } from '../../services/group.service';
import { ToastyService } from 'ng2-toasty';

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
    users: any[];
    group: any = {
        name: "",
        dbConfigId: 0,
        users: []
    };

    constructor(private groupService: GroupService, private toastyService: ToastyService) { }

    ngOnInit() {
        this.groupService.getCompanies().subscribe(companies =>
            this.companies = companies);
    }

    onCompanyChange() {

        this.group.users = [];
        this.group.dbConfigId = 0;

        if (this.group.companyId === '') {

            delete this.users;
            delete this.dbConfigs;
        }
        else {
            this.groupService
                .getAppUsers(this.group.companyId)
                .subscribe(appUsers => this.users = appUsers);

            this.groupService
                .getDbConfigs(this.group.companyId)
                .subscribe(dbConfigs => this.dbConfigs = dbConfigs);
        }
    }

    onUserToggle(userId: number, $event: { target: { checked: any; }; }) {

        if ($event.target.checked)
            this.group.users.push(userId);
        else {
            var index = this.group.users.indexOf(userId);
            this.group.users.splice(index, 1);
        }
    }

    submit() {
        this.groupService.create(this.group)
            .subscribe(x =>
                console.log(x),
                err => {
                    //if (err.status == 400) {

                    //}
                    this.toastyService.error({
                        title: 'Erro',
                        msg: 'Um erro inesperado ocorreu.',
                        theme: 'bootstrap',
                        showClose: true,
                        timeout: 5000
                    })
            }
        );
    }
}