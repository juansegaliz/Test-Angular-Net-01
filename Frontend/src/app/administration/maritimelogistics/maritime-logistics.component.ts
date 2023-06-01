import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Response } from 'src/app/core/models/response';
import { MaritimeLogistic } from 'src/app/core/models/maritime-logistic';
import { SnackbarService } from 'src/app/core/services/snackbar.service';
import { MaritimeLogisticService } from 'src/app/core/services/maritime-logistic.service';
import { DangerDialogComponent } from 'src/app/shared/components/dialogs/danger-dialog/danger-dialog.component';
import { ProductTypeService } from 'src/app/core/services/product-type.service';
import { ClientService } from 'src/app/core/services/client.service';
import { Select } from 'src/app/core/models/select';
import { PortService } from 'src/app/core/services/port.service';

@Component({
  selector: 'fro-maritime-logistics',
  templateUrl: './maritime-logistics.component.html',
  styleUrls: ['./maritime-logistics.component.scss'],
})
export class MaritimeLogisticsComponent implements OnInit {
  constructor(
    private formBuilder: FormBuilder,
    private maritimeLogisticService: MaritimeLogisticService,
    private snackbarService: SnackbarService,
    private dialog: MatDialog,
    private productTypeService: ProductTypeService,
    private portService: PortService,
    private clientService: ClientService
  ) {
    this.setForm();

    this.setSelectsData();
  }

  selectProductTypeData: Select[] = [];
  selectPortData: Select[] = [];
  selectClientData: Select[] = [];

  data: MaritimeLogistic[] = [];
  columnas: string[] = [
    'maritimeLogisticsId',
    'productTypeId',
    'quantity',
    'registrationDate',
    'deliveryDate',
    'portId',
    'shippingPrice',
    'discount',
    'totalPrice',
    'fleetNumber',
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
    this.selectPortData = await this.portService.getDataForSelect();
    this.selectClientData = await this.clientService.getDataForSelect();
  }

  onEditItem(item: MaritimeLogistic) {
    this.form.patchValue(item);
  }

  delete(item: MaritimeLogistic) {
    this.maritimeLogisticService.deleteMaritimeLogistic(item.maritimeLogisticsId).subscribe(
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
    this.data = (await this.maritimeLogisticService.getMaritimeLogistics()).data;
  }

  getForm(): FormGroup {
    return this.formBuilder.group({
      maritimeLogisticsId: null,
      productTypeId: [null, Validators.required],
      quantity: ['', Validators.required],
      registrationDate: ['', Validators.required],
      deliveryDate: ['', Validators.required],
      portId: [null, Validators.required],
      shippingPrice: ['', Validators.required],
      discount: [{ value: '', disabled: true }, Validators.required],
      totalPrice: [{ value: '', disabled: true }, Validators.required],
      fleetNumber: ['', Validators.required],
      guideNumber: ['', Validators.required],
      clientId: [null, Validators.required],
    });
  }

  async onSave(form: FormGroup): Promise<void> {
    const info: MaritimeLogistic = form.value;
    //Estamos usando aqui truthy or falsy,
    //Si Id es truthy (tiene valor distinto a null o 0), entonces actualice, sino guarde
    if (Boolean(info.maritimeLogisticsId)) await this.update(info);
    else await this.save(info);
    
  }

  async save(info: MaritimeLogistic): Promise<void> {
    this.maritimeLogisticService
      .addMaritimeLogistic(
        info.productTypeId,
        info.quantity,
        info.registrationDate,
        info.deliveryDate,
        info.portId,
        info.shippingPrice,
        info.fleetNumber,
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

  async update(info: MaritimeLogistic): Promise<void> {
    this.maritimeLogisticService
      .updateMaritimeLogistic(
        info.maritimeLogisticsId,
        info.productTypeId,
        info.quantity,
        info.registrationDate,
        info.deliveryDate,
        info.portId,
        info.shippingPrice,
        info.fleetNumber,
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

  openDialog(item: MaritimeLogistic) {
    const dialogRef = this.dialog.open(DangerDialogComponent, {
      data: {
        title: 'Eliminar Logistica maritima',
        message: '¿Seguro quieres eliminar esta logistica maritima?',
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
    const discount = (quantity > 10) ? shippingPrice * 0.03 : 0;

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
