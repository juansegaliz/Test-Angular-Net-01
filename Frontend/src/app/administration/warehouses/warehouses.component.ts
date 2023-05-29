import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { HttpWarehousesService } from 'src/app/core/services/http/http-warehouses.service';
import { Response } from 'src/app/core/models/response';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'fro-warehouses',
  templateUrl: './warehouses.component.html',
  styleUrls: ['./warehouses.component.scss'],
})
export class WarehousesComponent implements OnInit {
  constructor(
    private formBuilder: FormBuilder,
    private httpWarehousesService: HttpWarehousesService,
    private snackBar: MatSnackBar
  ) {
    this.addForm = this.getAddForm();
  }

  addForm: FormGroup;

  ngOnInit() {}

  getAddForm(): FormGroup {
    return this.formBuilder.group({
      name: ['', Validators.required],
      address: ['', Validators.required],
    });
  }

  async save(form: FormGroup): Promise<void> {
    const info = form.value;
    this.httpWarehousesService.post(info).subscribe(
      (responseSuccess: Response<boolean>) => {
        const message = Object.entries(responseSuccess.messages)
          .map(([key, value]) => `${value}`)
          .join(' ');

        this.snackBar.open(message, 'Close', {
          duration: 5000,
          panelClass: ['mat-snack-bar-container_success'],
        });

        
      },
      (responseError: any) => {
        const data = responseError.error.errors || responseError.error.messages;
        const message = Object.entries(data)
          .map(([key, value]) => `${value}`)
          .join(' ');
        this.snackBar.open(message, 'Close', {
          duration: 5000,
          panelClass: ['mat-snack-bar-container_error'],
        });
      },
      async () => {
        
        this.addForm = this.getAddForm();
      }
    );
  }
}
