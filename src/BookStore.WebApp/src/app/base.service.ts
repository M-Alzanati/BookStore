import { HttpHeaders } from "@angular/common/http";
import { environment } from '../environments/environment';

export class BaseService {

    url: string = environment.apiUrl;
    
    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json'
        })
    };
}