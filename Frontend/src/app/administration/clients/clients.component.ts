import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Response } from 'src/app/core/models/response';
import { Client } from 'src/app/core/models/client';
import { SnackbarService } from 'src/app/core/services/snackbar.service';
import { ClientService } from 'src/app/core/services/client.service';
import { DangerDialogComponent } from 'src/app/shared/components/dialogs/danger-dialog/danger-dialog.component';


@Component({
  selector: 'fro-clients',
  templateUrl: './clients.component.html',
  styleUrls: ['./clients.component.scss'],
})
export class ClientsComponent implements OnInit {
  constructor(
    private formBuilder: FormBuilder,
    private clientService: ClientService,
    private snackbarService: SnackbarService,
    private dialog: MatDialog
  ) {
    this.form = this.getForm();
  }

  data: Client[] = [];
  columnas: string[] = ['clientId', 'name', 'address', 'phone', 'actions'];

  form: FormGroup;

  async ngOnInit() {
    this.setDataTable();
  }

  onEditItem(item: Client) {
    this.form.patchValue(item);
  }

  delete(item: Client) {
    this.clientService.deleteClient(item.clientId).subscribe(
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
    this.data = (await this.clientService.getClients()).data;
  }

  getForm(): FormGroup {
    return this.formBuilder.group({
      clientId: null,
      name: ['', Validators.required],
      address: ['', Validators.required],
      phone: ['', Validators.required],
    });
  }

  async onSave(form: FormGroup): Promise<void> {
    const info: Client = form.value;
    //Estamos usando aqui truthy or falsy, 
    //Si Id es truthy (tiene valor distinto a null o 0), entonces actualice, sino guarde
    if (Boolean(info.clientId))
      await this.update(info);
    else
      await this.save(info);
  }

  async save(info: Client): Promise<void> {
    this.clientService.addClient(info.name, info.address, info.phone).subscribe(
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

  async update(info: Client): Promise<void> {
    this.clientService.updateClient(info.clientId, info.name, info.address, info.phone).subscribe(
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

  openDialog(item: Client) {
    const dialogRef = this.dialog.open(DangerDialogComponent, {
      data: {
        title: 'Eliminar Cliente',
        message: '¿Seguro quieres eliminar este cliente?'
      }
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.delete(item);
      }
    });
  }
}
