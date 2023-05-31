import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { AdministrationRoutingModule } from './administration-routing.module';
import { WarehousesComponent } from './warehouses/warehouses.component';
import { SharedModule } from '../shared/shared.module';


import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatIconModule } from '@angular/material/icon';
import { MatTableModule } from '@angular/material/table';
import { MatDialogModule } from '@angular/material/dialog';




@NgModule({
  declarations: [
    WarehousesComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    AdministrationRoutingModule,
    SharedModule,    
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatSnackBarModule,
    MatIconModule,
    MatTableModule,
    MatDialogModule
  ]
})
export class AdministrationModule { }
