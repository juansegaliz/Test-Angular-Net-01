import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Response } from 'src/app/core/models/response';
import { LandLogistic } from 'src/app/core/models/land-logistic';
import { SnackbarService } from 'src/app/core/services/snackbar.service';
import { LandLogisticService } from 'src/app/core/services/land-logistic.service';
import { DangerDialogComponent } from 'src/app/shared/components/dialogs/danger-dialog/danger-dialog.component';
import { ProductTypeService } from 'src/app/core/services/product-type.service';
import { WarehouseService } from 'src/app/core/services/warehouse.service';
import { ClientService } from 'src/app/core/services/client.service';
import { Select } from 'src/app/core/models/select';

@Component({
  selector: 'fro-land-logistics',
  templateUrl: './land-logistics.component.html',
  styleUrls: ['./land-logistics.component.scss'],
})
export class LandLogisticsComponent implements OnInit {
  constructor(
    private formBuilder: FormBuilder,
    private landLogisticService: LandLogisticService,
    private snackbarService: SnackbarService,
    private dialog: MatDialog,
    private productTypeService: ProductTypeService,
    private warehouseService: WarehouseService,
    private clientService: ClientService
  ) {
    this.setForm();

    this.setSelectsData();
  }

  selectProductTypeData: Select[] = [];
  selectWarehouseData: Select[] = [];
  selectClientData: Select[] = [];

  data: LandLogistic[] = [];
  columnas: string[] = [
    'landLogisticsId',
    'productTypeId',
    'quantity',
    'registrationDate',
    'deliveryDate',
    'warehouseId',
    'shippingPrice',
    'discount',
    'totalPrice',
    'vehiclePlate',
    'guideNumber',
    'clientId',
    'actions',
  ];

  form!: FormGroup;

  async ngOnInit() {
    this.setDataTable();
  }

  async setForm(): Promise<void> {
    this.form = this.getForm();

    this.form.valueChanges.subscribe(() => {
      const discount = this.calculateDiscount();
      const totalPrice = this.calculateTotal();

      if (this.form.get('discount')!.value !== discount || this.form.get('totalPrice')!.value !== totalPrice) {
        this.form.patchValue({
          discount: discount,
          totalPrice: totalPrice
        });
      }
    });
  }

  async setSelectsData(): Promise<void> {
    this.selectProductTypeData =
      await this.productTypeService.getDataForSelect();
    this.selectWarehouseData = await this.warehouseService.getDataForSelect();
    this.selectClientData = await this.clientService.getDataForSelect();
  }

  onEditItem(item: LandLogistic) {
    this.form.patchValue(item);
  }

  delete(item: LandLogistic) {
    this.landLogisticService.deleteLandLogistic(item.landLogisticsId).subscribe(
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
    this.data = (await this.landLogisticService.getLandLogistics()).data;
  }

  getForm(): FormGroup {
    return this.formBuilder.group({
      landLogisticsId: null,
      productTypeId: [null, Validators.required],
      quantity: ['', Validators.required],
      registrationDate: ['', Validators.required],
      deliveryDate: ['', Validators.required],
      warehouseId: [null, Validators.required],
      shippingPrice: ['', Validators.required],
      discount: [{ value: '', disabled: true }, Validators.required],
      totalPrice: [{ value: '', disabled: true }, Validators.required],
      vehiclePlate: ['', Validators.required],
      guideNumber: ['', Validators.required],
      clientId: [null, Validators.required],
    });
  }

  async onSave(form: FormGroup): Promise<void> {
    const info: LandLogistic = form.value;
    console.log(info);
    //Estamos usando aqui truthy or falsy,
    //Si Id es truthy (tiene valor distinto a null o 0), entonces actualice, sino guarde
    
    if (Boolean(info.landLogisticsId)) await this.update(info);
    else await this.save(info);
    
  }

  async save(info: LandLogistic): Promise<void> {
    this.landLogisticService
      .addLandLogistic(
        info.productTypeId,
        info.quantity,
        info.registrationDate,
        info.deliveryDate,
        info.warehouseId,
        info.shippingPrice,
        info.vehiclePlate,
        info.guideNumber,
        info.clientId
      )
      .subscribe(
        (responseSuccess: Response<boolean>) => {
          const message = Object.entries(responseSuccess.messages)
            .map(([key, value]) => `${value}`)
            .join(' ');

          this.snackbarService.openSuccess(message, 'close');
        },
        (responseError: any) => {
          const data =
            responseError.error.errors || responseError.error.messages;
          const message = Object.entries(data)
            .map(([key, value]) => `${value}`)
            .join(' ');

          this.snackbarService.openError(message, 'close');
        },
        async () => {
          await this.setForm();
          await this.setDataTable();
        }
      );
  }

  async update(info: LandLogistic): Promise<void> {
    this.landLogisticService
      .updateLandLogistic(
        info.landLogisticsId,
        info.productTypeId,
        info.quantity,
        info.registrationDate,
        info.deliveryDate,
        info.warehouseId,
        info.shippingPrice,
        info.vehiclePlate,
        info.guideNumber,
        info.clientId
      )
      .subscribe(
        (responseSuccess: Response<boolean>) => {
          const message = Object.entries(responseSuccess.messages)
            .map(([key, value]) => `${value}`)
            .join(' ');

          this.snackbarService.openSuccess(message, 'close');
        },
        (responseError: any) => {
          const data =
            responseError.error.errors || responseError.error.messages;
          const message = Object.entries(data)
            .map(([key, value]) => `${value}`)
            .join(' ');

          this.snackbarService.openError(message, 'close');
        },
        async () => {
          await this.setForm();
          await this.setDataTable();
        }
      );
  }

  openDialog(item: LandLogistic) {
    const dialogRef = this.dialog.open(DangerDialogComponent, {
      data: {
        title: 'Eliminar Logistica terrestre',
        message: '¿Seguro quieres eliminar esta logistica terrestre?',
      },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.delete(item);
      }
    });
  }

  calculateDiscount(): number {
    const quantity = this.form.get('quantity')!.value;
    const shippingPrice = this.form.get('shippingPrice')!.value;
    const discount = (quantity > 10) ? shippingPrice * 0.05 : 0;

    return discount;
  }


  calculateTotal(): number {
    const quantity = this.form.get('quantity')!.value;
    const shippingPrice = this.form.get('shippingPrice')!.value;
    const discount = this.calculateDiscount();
    const total = (quantity > 10) ? shippingPrice - discount : shippingPrice;

    return total;
  }

  displayText(id: number, selectData: Select[]) {
    const foundItem = selectData.find(
      item => item.value === id
    );
  
    return foundItem ? foundItem.text : '';
  }
}
