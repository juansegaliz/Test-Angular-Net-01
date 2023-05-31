import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environment/environment';
import { ProductType } from '../../models/product-type';
import { Response } from '../../models/response';

@Injectable({
  providedIn: 'root'
})
export class HttpProductTypesService {
  private serverUrl = environment.serverUrl;

  constructor(private httpClient: HttpClient) { }
  
  getAll(): Observable<Response<ProductType[]>> {
    return this.httpClient.get<Response<ProductType[]>>(`${this.serverUrl}/productTypes`);
  }
  
  post(info: ProductType): Observable<Response<boolean>> {
    return this.httpClient.post<Response<boolean>>(`${this.serverUrl}/productTypes`, info);
  }
  
  get(id: number): Observable<Response<ProductType>> {
    return this.httpClient.get<Response<ProductType>>(`${this.serverUrl}/productTypes/${id}`);
  }
  
  put(id: number, info: ProductType): Observable<Response<boolean>> {
    return this.httpClient.put<Response<boolean>>(`${this.serverUrl}/productTypes/${id}`, info);
  }
  
  delete(id: number): Observable<Response<boolean>> {
    return this.httpClient.delete<Response<boolean>>(`${this.serverUrl}/productTypes/${id}`);
  }
}
