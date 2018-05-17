import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { GroupService } from '../../services/group.service';
import { ToastyService } from 'ng2-toasty';

@Component({
    selector: 'group-view',
    templateUrl: './group-view.component.html',
    styleUrls: ['./group-view.component.css']
})
/** group-view component*/
export class GroupViewComponent implements OnInit{

    group: any;
    groupId: number = 0;

    /** group-view ctor */
    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private groupService: GroupService,
        private toastyService: ToastyService
    ) {
        route.params.subscribe(p => {
            this.groupId = +p['id'];
            if (isNaN(this.groupId) || this.groupId <= 0) {
                this.router.navigate(['/groups']);
                return;
            }
        });
    }

    ngOnInit() {
        this.groupService.getGroup(this.groupId)
            .subscribe(
            g => this.group = g,
            err => {
                if (err.status == 404) {
                    this.router.navigate(['/groups']);
                    return;
                }
            });
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