import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { AuthenticationService } from 'src/app/auth/auth.service';
import { MatDialog } from '@angular/material/dialog';
import { DialogData, MessageBoxComponent } from '../components/message-dialog/message-dialog-component';
import { DashBoardService } from './dashboard.service';
import { TenantModel } from '../models/tenant-model';
import { SharedService } from 'src/app/shared/services';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
    selector: 'app-dashboard',
    templateUrl: './dashboard.component.html',
    styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

    tenants: TenantModel[] = [];

    constructor(
        private dashboradService: DashBoardService,
        private dialog: MatDialog,
        private sharedService: SharedService,
        private spinner: NgxSpinnerService
    ) {

    }

    ngOnInit() {
        this.spinner.show();

        this.dashboradService
            .getTenants()
            .subscribe(
                (myTenants: TenantModel[]) => {
                    this.spinner.hide();
                    myTenants.forEach((v) => {
                        this.tenants.push(v);
                        this.sharedService.addTenants.next(v);
                    });
                },
                (error) => {
                    this.spinner.hide();
                    let msg: DialogData = { title: 'Error', content: error };
                    this.dialog.open(MessageBoxComponent, { data: msg });
                }
            );
    }
}
