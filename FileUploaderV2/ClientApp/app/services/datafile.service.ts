import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

@Injectable()
export class DatafileService {
    constructor(private http: Http) {

    }

    upload(userId: number, file: File) {

        var formData = new FormData();
        formData.append('file', file);

        return this.http.post(`/api/users/${userId}/datafiles`, formData)
            .map(res => res.json());
    }

    getDataFiles(userId: number) {
        return this.http.get(`/api/users/${userId}/datafiles`)
            .map(res => res.json());
    }
}