import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BaseService } from 'src/app/base.service';
import { Observable, of } from 'rxjs';
import { TenantModel } from '../models/tenant-model';
import { catchError, map } from 'rxjs/operators';

@Injectable()
export class DashBoardService extends BaseService {
    constructor(private http: HttpClient) {
        super();
    }

    getTenants(): Observable<TenantModel[]> {
        return this.http
            .get(`${this.url}/tenants`, this.httpOptions)
            .pipe(
                map(response => {
                    return response;
                }),
                catchError(e => {
                    return of(null);
                })
            );
    }
}
