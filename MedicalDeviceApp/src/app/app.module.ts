import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatTabsModule } from '@angular/material/tabs';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatCardModule } from '@angular/material/card';
import { MatSelectModule } from '@angular/material/select';
import { ReactiveFormsModule } from '@angular/forms';
import { MatListModule } from '@angular/material/list';
import { HttpClientModule } from '@angular/common/http';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';

import { MatExpansionModule } from '@angular/material/expansion';
import { MatPaginatorModule } from '@angular/material/paginator';
import { BlobPipe } from './pipes/blob.pipe';

import { ApiModule } from 'src/api';

import { AppConfig } from 'src/app/app.config';
import { AppRouting } from 'src/app/app.routing';

import { RootPage } from 'src/app/pages/root/root.page';
import { UsersPage } from 'src/app/pages/users/users.page';
import { DevicesPage } from 'src/app/pages/devices/devices.page';
import { TicketsPage } from 'src/app/pages/tickets/tickets.page';
import { UserComponent } from './components/user/user.component';
import { BlobComponent } from './components/blob/blob.component';
import { DeviceComponent } from './components/device/device.component';

@NgModule({
  declarations: [
    BlobPipe,
    RootPage,
    UsersPage,
    DevicesPage,
    TicketsPage,
    BlobComponent,
    UserComponent,
    DeviceComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    MatIconModule,
    MatTabsModule,
    MatToolbarModule,
    MatSelectModule,
    MatCardModule,
    MatListModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatExpansionModule,
    MatPaginatorModule,
    MatDialogModule,
    AppRouting,
    ApiModule.forRoot(() => AppConfig)
  ],
  providers: [],
  bootstrap: [
    RootPage
  ]
})
export class AppModule { }
