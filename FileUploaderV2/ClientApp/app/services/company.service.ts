import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class CompanyService {
    constructor(private http: Http) {

    }
    getCompanies() {
        return this.http.get('/api/companies')
            .map(res => res.json());
    }
}