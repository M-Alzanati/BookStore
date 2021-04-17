import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { AuthenticationService } from 'src/app/auth/auth.service';
import { MatDialog } from '@angular/material/dialog';
import { DialogData, MessageBoxComponent } from '../components/message-dialog/message-dialog-component';
import { DashBoardService } from './dashboard.service';
import { TenantModel } from '../models/tenant-model';

@Component({
    selector: 'app-dashboard',
    templateUrl: './dashboard.component.html',
    styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

    tenants: TenantModel[] = [];

    constructor(private dashboradService: DashBoardService, private dialog: MatDialog) {

    }

    ngOnInit() {
        this.dashboradService
            .getTenants()
            .subscribe(
                (myTenants: TenantModel[]) => {
                    myTenants.forEach((v) => {
                        this.tenants.push(v);
                        this.dashboradService.TenantModels[v.name] = v.apiKey;
                    });
                },
                (error) => {
                    let msg: DialogData = { title: 'Error', content: error };
                    this.dialog.open(MessageBoxComponent, {data: msg});
                }
            );
    }
}
