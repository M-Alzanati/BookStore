import { HttpHeaders } from "@angular/common/http";
import { environment } from '../environments/environment';
import { TenantModel } from "./layout/models/tenant-model";

export class BaseService {

    url: string = environment.apiUrl;
    
    TenantModels = {};
    
    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json'
        })
    };
}