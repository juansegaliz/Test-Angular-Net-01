import { Injectable } from '@angular/core';
import { HttpClientsService } from './http/http-clients.service';
import { Client } from '../models/client';
import { Response } from '../models/response';
import { lastValueFrom, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ClientService {

  constructor(private httpClientsService: HttpClientsService) { }

  addClient(name: string, address: string, phone: string): Observable<Response<boolean>> {
    const info: Client = {
      clientId: 0,
      name: name,
      address: address,
      phone: phone
    };
    return this.httpClientsService.post(info);
  }

  updateClient(clientId: number, name: string, address: string, phone: string): Observable<Response<boolean>> {
    const info: Client = {
      clientId: clientId,
      name: name,
      address: address,
      phone: phone
    };
    return this.httpClientsService.put(clientId, info);
  }

  deleteClient(clientId: number): Observable<Response<boolean>> {
    return this.httpClientsService.delete(clientId);
  }

  async getClients(): Promise<Response<Client[]>> {
    const response = await lastValueFrom(this.httpClientsService.getAll());
    return response;
  }
}
