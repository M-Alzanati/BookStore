import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { AuthenticationService } from 'src/app/auth/auth.service';
import { MatDialog } from '@angular/material/dialog';
import { DialogData, MessageBoxComponent } from '../components/message-dialog/message-dialog-component';

export interface PeriodicElement {
    name: string;
    time: string;
}

@Component({
    selector: 'app-dashboard',
    templateUrl: './dashboard.component.html',
    styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

    constructor(private auth: AuthenticationService, private dialog: MatDialog) {

    }

    ngOnInit() {

    }

    onFormSubmit() {

    }
}
