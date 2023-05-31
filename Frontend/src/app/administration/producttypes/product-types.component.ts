import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Response } from 'src/app/core/models/response';
import { ProductType } from 'src/app/core/models/product-type';
import { SnackbarService } from 'src/app/core/services/snackbar.service';
import { ProductTypeService } from 'src/app/core/services/product-type.service';
import { DangerDialogComponent } from 'src/app/shared/components/dialogs/danger-dialog/danger-dialog.component';


@Component({
  selector: 'fro-producttypes',
  templateUrl: './product-types.component.html',
  styleUrls: ['./product-types.component.scss'],
})
export class ProductTypesComponent implements OnInit {
  constructor(
    private formBuilder: FormBuilder,
    private productTypeService: ProductTypeService,
    private snackbarService: SnackbarService,
    private dialog: MatDialog
  ) {
    this.form = this.getForm();
  }

  data: ProductType[] = [];
  columnas: string[] = ['productTypeId', 'name', 'actions'];

  form: FormGroup;

  async ngOnInit() {
    this.setDataTable();
  }

  onEditItem(item: ProductType) {
    this.form.patchValue(item);
  }

  delete(item: ProductType) {
    this.productTypeService.deleteProductType(item.productTypeId).subscribe(
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
    this.data = (await this.productTypeService.getProductTypes()).data;
  }

  getForm(): FormGroup {
    return this.formBuilder.group({
      productTypeId: null,
      name: ['', Validators.required],
      address: ['', Validators.required],
    });
  }

  async onSave(form: FormGroup): Promise<void> {
    const info: ProductType = form.value;
    //Estamos usando aqui truthy or falsy, 
    //Si Id es truthy (tiene valor distinto a null o 0), entonces actualice, sino guarde
    if (Boolean(info.productTypeId))
      await this.update(info);
    else
      await this.save(info);
  }

  async save(info: ProductType): Promise<void> {
    this.productTypeService.addProductType(info.name).subscribe(
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

  async update(info: ProductType): Promise<void> {
    console.log(this.update);
    this.productTypeService.updateProductType(info.productTypeId, info.name).subscribe(
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

  openDialog(item: ProductType) {
    const dialogRef = this.dialog.open(DangerDialogComponent, {
      data: {
        title: 'Eliminar Tipo de producto',
        message: '¿Seguro quieres eliminar este tipo de producto?'
      }
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.delete(item);
      }
    });
  }
}
