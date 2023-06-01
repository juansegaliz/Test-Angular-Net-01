import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environment/environment';
import { MaritimeLogistic } from '../../models/maritime-logistic';
import { Response } from '../../models/response';

@Injectable({
  providedIn: 'root'
})
export class HttpMaritimeLogisticsService {
  private serverUrl = environment.serverUrl;

  constructor(private httpClient: HttpClient) { }
  
  getAll(): Observable<Response<MaritimeLogistic[]>> {
    return this.httpClient.get<Response<MaritimeLogistic[]>>(`${this.serverUrl}/maritimeLogistics`);
  }
  
  post(info: MaritimeLogistic): Observable<Response<boolean>> {
    return this.httpClient.post<Response<boolean>>(`${this.serverUrl}/maritimeLogistics`, info);
  }
  
  get(id: number): Observable<Response<MaritimeLogistic>> {
    return this.httpClient.get<Response<MaritimeLogistic>>(`${this.serverUrl}/maritimeLogistics/${id}`);
  }
  
  put(id: number, info: MaritimeLogistic): Observable<Response<boolean>> {
    return this.httpClient.put<Response<boolean>>(`${this.serverUrl}/maritimeLogistics/${id}`, info);
  }
  
  delete(id: number): Observable<Response<boolean>> {
    return this.httpClient.delete<Response<boolean>>(`${this.serverUrl}/maritimeLogistics/${id}`);
  }
}
