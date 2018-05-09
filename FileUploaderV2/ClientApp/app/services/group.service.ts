import { Injectable, keyframes } from '@angular/core';
import { Http } from '@angular/http'; 
import 'rxjs/add/operator/map';
import { SaveGroup } from '../Models/saveGroup';

@Injectable()
export class GroupService {
    constructor(private http: Http) { }

    getGroup(id: number) {
        return this.http.get('/api/groups/' + id)
            .map(res => res.json());
    }

    getGroups(id: number) {
        return this.http.get('/api/groups/getGroups', {
            params: { 'id': id }
        })
            .map(res => res.json());
    }
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

    update(group: SaveGroup) {
        return this.http.put('/api/groups/' + group.id, group)
            .map(res => res.json());
    }

    delete(id: number) {
        return this.http.delete('/api/groups/' + id)
            .map(res => res.json());
    }
}