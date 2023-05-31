import { Injectable } from '@angular/core';
import { HttpPortsService } from './http/http-ports.service';
import { Port } from '../models/port';
import { Response } from '../models/response';
import { lastValueFrom, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PortService {

  constructor(private httpPortsService: HttpPortsService) { }

  addPort(name: string, city: string, country: string): Observable<Response<boolean>> {
    const info: Port = {
      portId: 0,
      name: name,
      city: city,
      country: country
    };
    return this.httpPortsService.post(info);
  }

  updatePort(portId: number, name: string, city: string, country: string): Observable<Response<boolean>> {
    const info: Port = {
      portId: portId,
      name: name,
      city: city,
      country: country
    };
    return this.httpPortsService.put(portId, info);
  }

  deletePort(portId: number): Observable<Response<boolean>> {
    return this.httpPortsService.delete(portId);
  }

  async getPorts(): Promise<Response<Port[]>> {
    const response = await lastValueFrom(this.httpPortsService.getAll());
    return response;
  }
}
