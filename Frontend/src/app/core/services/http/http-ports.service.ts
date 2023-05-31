import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environment/environment';
import { Port } from '../../models/port';
import { Response } from '../../models/response';

@Injectable({
  providedIn: 'root'
})
export class HttpPortsService {
  private serverUrl = environment.serverUrl;

  constructor(private httpClient: HttpClient) { }
  
  getAll(): Observable<Response<Port[]>> {
    return this.httpClient.get<Response<Port[]>>(`${this.serverUrl}/ports`);
  }
  
  post(info: Port): Observable<Response<boolean>> {
    return this.httpClient.post<Response<boolean>>(`${this.serverUrl}/ports`, info);
  }
  
  get(id: number): Observable<Response<Port>> {
    return this.httpClient.get<Response<Port>>(`${this.serverUrl}/ports/${id}`);
  }
  
  put(id: number, info: Port): Observable<Response<boolean>> {
    return this.httpClient.put<Response<boolean>>(`${this.serverUrl}/ports/${id}`, info);
  }
  
  delete(id: number): Observable<Response<boolean>> {
    return this.httpClient.delete<Response<boolean>>(`${this.serverUrl}/ports/${id}`);
  }
}
