import { Injectable } from '@angular/core';
import { Http } from '@angular/http'; 
import 'rxjs/add/operator/map';

@Injectable()
export class GroupService {
    constructor(private http: Http) { }

    getAppUsers() {
        return this.http.get('/api/appusers')
            .map(res => res.json());
    }

    getCompanies() {
        return this.http.get('/api/companies')
            .map(res => res.json());
    }
}