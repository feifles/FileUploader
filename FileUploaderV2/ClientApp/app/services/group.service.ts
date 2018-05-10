import { Injectable, keyframes } from '@angular/core';
import { Http } from '@angular/http'; 
import 'rxjs/add/operator/map';
import { SaveGroup } from '../Models/saveGroup';

@Injectable()
export class GroupService {

    private readonly groupsEndpoint = '/api/groups';

    constructor(private http: Http) { }

    getGroup(id: number) {
        return this.http.get(this.groupsEndpoint + '/' + id)
            .map(res => res.json());
    }

    getGroups(filter: any) {
            return this.http.get(this.groupsEndpoint + '/GetAllGroups' + '?' + this.toQueryString(filter))
                .map(res => res.json());
    }

    toQueryString(obj: any) {
        var parts = [];
        for (var property in obj) {
            var value = obj[property];
            if (value != null && value != undefined) {
                parts.push(encodeURIComponent(property) + '=' + encodeURIComponent(value));
            }
        }

        return parts.join('&');
    }

    getCompanyGroups(id: number) {
        return this.http.get('/api/groups/getGroups', {
            params: { 'id': id }
        }).map(res => res.json());
    }

    getAppUsers(id: number) {
        return this.http.get('/api/users/company/' + id)
            .map(res => res.json());
    }

    getDbConfigs(id: number = 0) {

        if (id == 0) {
            return this.http.get('/api/DbConfig')
                .map(res => res.json());
        }

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