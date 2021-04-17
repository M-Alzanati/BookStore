import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { AuthenticationService } from 'src/app/auth/auth.service';
import { MatDialog } from '@angular/material/dialog';
import { DialogData, MessageBoxComponent } from '../components/message-dialog/message-dialog-component';

@Component({
    selector: 'app-dashboard',
    templateUrl: './dashboard.component.html',
    styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

    bookstore1: string = 'BookStore 1';
    bookstore2: string = 'BookStore 2';

    constructor(private auth: AuthenticationService, private dialog: MatDialog) {

    }

    ngOnInit() {

    }

    onFormSubmit() {

    }
}
