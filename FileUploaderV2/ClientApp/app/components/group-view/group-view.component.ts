import { Component, OnInit, ElementRef, ViewChild, NgZone } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { GroupService } from '../../services/group.service';
import { ToastyService } from 'ng2-toasty';
import { DatafileService } from '../../services/datafile.service';
import { ProgressService } from '../../services/progress.service';

@Component({
    selector: 'group-view',
    templateUrl: './group-view.component.html',
    styleUrls: ['./group-view.component.css']
})
/** group-view component*/
export class GroupViewComponent implements OnInit{

    @ViewChild('fileInput') fileInput: ElementRef;
    group: any;
    groupId: number = 0;
    dataFiles: any[];
    progress: any;

    /** group-view ctor */
    constructor(
        private zone: NgZone,
        private route: ActivatedRoute,
        private router: Router,
        private groupService: GroupService,
        private toastyService: ToastyService,
        private dataFileService: DatafileService,
        private progressService: ProgressService
    ) {
        route.params.subscribe(p => {
            this.groupId = +p['id'];
            if (isNaN(this.groupId) || this.groupId <= 0) {
                this.router.navigate(['/groups']);
                return;
            }
        });

        this.dataFiles = [];
    }

    ngOnInit() {

        this.dataFileService.getDataFiles(37)
            .subscribe(dataFiles => this.dataFiles = dataFiles);

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

    uploadFile() {
        this.progressService.startTracking()
            .subscribe(progress => {

                this.zone.run(() => {
                    this.progress = progress;
                });
            },
            () => { },
            () => { this.progress = null; });

        var nativeElement: HTMLInputElement = this.fileInput.nativeElement;
        var file = nativeElement.files != null? nativeElement.files[0] : null;
        nativeElement.value = '';

        if (file != null)
            this.dataFileService.upload(37, file)
                .subscribe(x => {
                    this.dataFiles.push(x);
                },
                err => {
                    this.toastyService.error({
                        title: 'Erro',
                        msg: err.text(),
                        theme: 'bootstrap',
                        showClose: true,
                        timeout: 5000
                    });
                });
    }
}