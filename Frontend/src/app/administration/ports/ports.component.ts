import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Response } from 'src/app/core/models/response';
import { Port } from 'src/app/core/models/port';
import { SnackbarService } from 'src/app/core/services/snackbar.service';
import { PortService } from 'src/app/core/services/port.service';
import { DangerDialogComponent } from 'src/app/shared/components/dialogs/danger-dialog/danger-dialog.component';

@Component({
  selector: 'fro-ports',
  templateUrl: './ports.component.html',
  styleUrls: ['./ports.component.scss']
})
export class PortsComponent {
  constructor(
    private formBuilder: FormBuilder,
    private portService: PortService,
    private snackbarService: SnackbarService,
    private dialog: MatDialog
  ) {
    this.form = this.getForm();
  }

  data: Port[] = [];
  columnas: string[] = ['portId', 'name', 'city', 'country', 'actions'];
  
  form: FormGroup;

  async ngOnInit() {
    this.setDataTable();
  }

  onEditItem(item: Port) {
    this.form.patchValue(item);
  }

  delete(item: Port) {
    this.portService.deletePort(item.portId).subscribe(
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
    this.data = (await this.portService.getPorts()).data;
  }

  getForm(): FormGroup {
    return this.formBuilder.group({
      portId: null,
      name: ['', Validators.required],
      city: ['', Validators.required],
      country: ['', Validators.required],
    });
  }

  async onSave(form: FormGroup): Promise<void> {
    const info: Port = form.value;
    //Estamos usando aqui truthy or falsy, 
    //Si Id es truthy (tiene valor distinto a null o 0), entonces actualice, sino guarde
    if (Boolean(info.portId))
      await this.update(info);
    else
      await this.save(info);
  }

  async save(info: Port): Promise<void> {
    this.portService.addPort(info.name, info.city, info.country).subscribe(
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

  async update(info: Port): Promise<void> {
    console.log(this.update);
    this.portService.updatePort(info.portId, info.name, info.city, info.country).subscribe(
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

  openDialog(item: Port) {
    const dialogRef = this.dialog.open(DangerDialogComponent, {
      data: {
        title: 'Eliminar Puerto',
        message: '¿Seguro quieres eliminar este puerto?'
      }
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.delete(item);
      }
    });
  }
}


