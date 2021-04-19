import { CommonModule } from '@angular/common';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { TranslateModule } from '@ngx-translate/core';
import { MaterialModule } from '../shared/modules/material/material.module';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { TopnavComponent } from './components/topnav/topnav.component';
import { LayoutRoutingModule } from './layout-routing.module';
import { LayoutComponent } from './layout.component';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { StatModule } from '../shared/modules/stat/stat.module';
import { MessageBoxComponent } from './components/message-dialog/message-dialog-component';
import { BookstoreDetailsComponent } from './components/bookstore-details/bookstore-details.component';
import { BookStoreDetailService } from './components/bookstore-details/bookstore.details.service';
import { ReactiveFormsModule } from '@angular/forms';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MatTableModule } from '@angular/material/table';

@NgModule({
    imports: [
        CommonModule,
        LayoutRoutingModule,
        MaterialModule,
        TranslateModule,
        MatDatepickerModule,
        ReactiveFormsModule,
        MatTableModule,
        StatModule,
        FlexLayoutModule.withConfig({ addFlexToParent: false }),
    ],
    declarations: [
        LayoutComponent,
        TopnavComponent,
        SidebarComponent,
        MessageBoxComponent,
        BookstoreDetailsComponent
    ],
    providers: [
        BookStoreDetailService
    ],
    schemas: [
        CUSTOM_ELEMENTS_SCHEMA
    ]
})
export class LayoutModule { }
