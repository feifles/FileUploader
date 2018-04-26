import { Injectable } from '@angular/core';
import { Http } from '@angular/http'; 
import 'rxjs/add/operator/map';

@Injectable()
export class GroupService {
    constructor(private http: Http) { }

    getAppUsers(id: number) {
        return this.http.get('/api/users/company/' + id)
            .map(res => res.json());
    }

    getDbConfigs(id: number) {
        return this.http.get('/api/DbConfig/Company/' + id)
            .map(res => res.json());
    }

    getCompanies() {
        return this.http.get('/api/companies')
            .map(res => res.json());
    }

    create(group: any) {
        return this.http.post('/api/groups', group)
            .map(res => res.json());
    }
}