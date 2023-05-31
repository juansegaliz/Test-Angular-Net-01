import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Response } from 'src/app/core/models/response';
import { Warehouse } from 'src/app/core/models/warehouses';
import { SnackbarService } from 'src/app/core/services/snackbar.service';
import { WarehouseService } from 'src/app/core/services/warehouse.service';
import { DangerDialogComponent } from 'src/app/shared/components/dialogs/danger-dialog/danger-dialog.component';


@Component({
  selector: 'fro-warehouses',
  templateUrl: './warehouses.component.html',
  styleUrls: ['./warehouses.component.scss'],
})
export class WarehousesComponent implements OnInit {
  constructor(
    private formBuilder: FormBuilder,
    private warehouseService: WarehouseService,
    private snackbarService: SnackbarService,
    private dialog: MatDialog
  ) {
    this.form = this.getForm();
  }

  data: Warehouse[] = [];
  columnas: string[] = ['warehouseID', 'name', 'address', 'actions'];

  form: FormGroup;

  async ngOnInit() {
    this.setDataTable();
  }

  onEditItem(item: Warehouse) {
    this.form.patchValue(item);
  }

  delete(item: Warehouse) {
    this.warehouseService.deleteWarehouse(item.warehouseId).subscribe(
      (responseSuccess: Response<boolean>) => {
        const message = Object.entries(responseSuccess.messages)
          .map(([key, value]) => `${value}`)
          .join(' ');

        this.snackbarService.openSuccess(message, 'close');
      },
      (responseError: any) => {
        const data = responseError.error.errors || responseError.error.messages;
        const message = Object.entries(data)
          .map(([key, value]) => `${value}`)
          .join(' ');

        this.snackbarService.openError(message, 'close');
      },
      async () => {
        await this.setDataTable();
      }
    );
  }

  async setDataTable() {
    this.data = (await this.warehouseService.getWarehouses()).data;
  }

  getForm(): FormGroup {
    return this.formBuilder.group({
      warehouseId: null,
      name: ['', Validators.required],
      address: ['', Validators.required],
    });
  }

  async onSave(form: FormGroup): Promise<void> {
    const info: Warehouse = form.value;
    //Estamos usando aqui truthy or falsy, 
    //Si warehouseId es truthy (tiene valor distinto a null o 0), entonces actualice, sino guarde
    if (Boolean(info.warehouseId))
      await this.update(info);
    else
      await this.save(info);
  }

  async save(info: Warehouse): Promise<void> {
    this.warehouseService.addWarehouse(info.name, info.address).subscribe(
      (responseSuccess: Response<boolean>) => {
        const message = Object.entries(responseSuccess.messages)
          .map(([key, value]) => `${value}`)
          .join(' ');

        this.snackbarService.openSuccess(message, 'close');
      },
      (responseError: any) => {
        const data = responseError.error.errors || responseError.error.messages;
        const message = Object.entries(data)
          .map(([key, value]) => `${value}`)
          .join(' ');

        this.snackbarService.openError(message, 'close');
      },
      async () => {
        this.form = this.getForm();
        await this.setDataTable();
      }
    );
  }

  async update(info: Warehouse): Promise<void> {
    console.log(this.update);
    this.warehouseService.updateWarehouse(info.warehouseId, info.name, info.address).subscribe(
      (responseSuccess: Response<boolean>) => {
        const message = Object.entries(responseSuccess.messages)
          .map(([key, value]) => `${value}`)
          .join(' ');

        this.snackbarService.openSuccess(message, 'close');
      },
      (responseError: any) => {
        const data = responseError.error.errors || responseError.error.messages;
        const message = Object.entries(data)
          .map(([key, value]) => `${value}`)
          .join(' ');

        this.snackbarService.openError(message, 'close');
      },
      async () => {
        this.form = this.getForm();
        await this.setDataTable();
      }
    );
  }

  openDialog(item: Warehouse) {
    const dialogRef = this.dialog.open(DangerDialogComponent, {
      data: {
        title: 'Eliminar Almacen',
        message: '¿Seguro quieres eliminar este almacen?'
      }
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.delete(item);
      }
    });
  }
}
