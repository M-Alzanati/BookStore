import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { TenantModel } from 'src/app/layout/models/tenant-model';

@Injectable({
    providedIn: 'root'
})
export class SharedService {
    addTenants: BehaviorSubject<TenantModel>;

    constructor() {
        this.addTenants = new BehaviorSubject<TenantModel>({ apiKey: '', name: '' });
    }
}