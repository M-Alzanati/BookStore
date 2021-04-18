import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from '../auth.service';
import { LoginModel } from '../models/login-model';
import { FormGroup, FormControl } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
    userForm: FormGroup = new FormGroup({
        email: new FormControl(''),
        password: new FormControl('')
    });

    constructor(
        private router: Router,
        private auth: AuthenticationService,
        private spinner: NgxSpinnerService) {

    }

    ngOnInit() {

    }

    onFormSubmit() {
        let model: LoginModel = {
            Email: this.userForm.get('email').value,
            Password: this.userForm.get('password').value
        };

        this.spinner.show();

        this.auth.login(model)
            .subscribe(
                res => {
                    this.spinner.hide();
                    if (res) {
                        this.router.navigate(['/app/dashboard']);
                    }
                },
                err => {
                    this.spinner.hide();
                }
            );
    }
}
