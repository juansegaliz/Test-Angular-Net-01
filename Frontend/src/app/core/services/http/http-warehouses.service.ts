import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environment/environment';
import { Warehouse } from '../../models/warehouse';
import { Response } from '../../models/response';

@Injectable({
  providedIn: 'root'
})
export class HttpWarehousesService {
  private serverUrl = environment.serverUrl;

  constructor(private httpClient: HttpClient) { }
  
  getAll(): Observable<Response<Warehouse[]>> {
    return this.httpClient.get<Response<Warehouse[]>>(`${this.serverUrl}/warehouses`);
  }
  
  post(info: Warehouse): Observable<Response<boolean>> {
    return this.httpClient.post<Response<boolean>>(`${this.serverUrl}/warehouses`, info);
  }
  
  get(id: number): Observable<Response<Warehouse>> {
    return this.httpClient.get<Response<Warehouse>>(`${this.serverUrl}/warehouses/${id}`);
  }
  
  put(id: number, info: Warehouse): Observable<Response<boolean>> {
    return this.httpClient.put<Response<boolean>>(`${this.serverUrl}/warehouses/${id}`, info);
  }
  
  delete(id: number): Observable<Response<boolean>> {
    return this.httpClient.delete<Response<boolean>>(`${this.serverUrl}/warehouses/${id}`);
  }
}
