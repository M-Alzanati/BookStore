import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FlexLayoutModule } from '@angular/flex-layout';

import { LoginComponent } from './login/login.component';
import { AuthRoutingModule } from './auth-routing.module';
import { MaterialModule } from '../shared/modules/material/material.module';
import { AuthenticationService } from './auth.service';
import { ReactiveFormsModule } from '@angular/forms';
import { NgxSpinnerModule } from 'ngx-spinner';

@NgModule({
    imports: [
        CommonModule,
        AuthRoutingModule,
        MaterialModule,
        ReactiveFormsModule,
        FlexLayoutModule.withConfig({ addFlexToParent: false }),
        NgxSpinnerModule
    ],
    declarations: [LoginComponent],
    schemas: [
        CUSTOM_ELEMENTS_SCHEMA
    ]
})
export class AuthModule { }
