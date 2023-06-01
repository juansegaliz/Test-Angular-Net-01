import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environment/environment';
import { Client } from '../../models/client';
import { Response } from '../../models/response';

@Injectable({
  providedIn: 'root'
})
export class HttpClientsService {
  private serverUrl = environment.serverUrl;

  constructor(private httpClient: HttpClient) { }
  
  getAll(): Observable<Response<Client[]>> {
    return this.httpClient.get<Response<Client[]>>(`${this.serverUrl}/clients`);
  }
  
  post(info: Client): Observable<Response<boolean>> {
    return this.httpClient.post<Response<boolean>>(`${this.serverUrl}/clients`, info);
  }
  
  get(id: number): Observable<Response<Client>> {
    return this.httpClient.get<Response<Client>>(`${this.serverUrl}/clients/${id}`);
  }
  
  put(id: number, info: Client): Observable<Response<boolean>> {
    return this.httpClient.put<Response<boolean>>(`${this.serverUrl}/clients/${id}`, info);
  }
  
  delete(id: number): Observable<Response<boolean>> {
    return this.httpClient.delete<Response<boolean>>(`${this.serverUrl}/clients/${id}`);
  }
}
