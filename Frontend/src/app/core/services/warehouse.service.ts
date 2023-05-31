import { Injectable } from '@angular/core';
import { HttpWarehousesService } from './http/http-warehouses.service';
import { Warehouse } from '../models/warehouse';
import { Response } from '../models/response';
import { lastValueFrom, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class WarehouseService {

  constructor(private httpWarehousesService: HttpWarehousesService) { }

  addWarehouse(name: string, address: string): Observable<Response<boolean>> {
    const info: Warehouse = {
      warehouseId: 0,
      name: name,
      address: address
    };
    return this.httpWarehousesService.post(info);
  }

  updateWarehouse(warehouseId: number, name: string, address: string): Observable<Response<boolean>> {
    const info: Warehouse = {
      warehouseId: warehouseId,
      name: name,
      address: address
    };
    return this.httpWarehousesService.put(warehouseId, info);
  }

  deleteWarehouse(warehouseId: number): Observable<Response<boolean>> {
    return this.httpWarehousesService.delete(warehouseId);
  }

  async getWarehouses(): Promise<Response<Warehouse[]>> {
    const response = await lastValueFrom(this.httpWarehousesService.getAll());
    return response;
  }
}
