import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environment/environment';
import { LandLogistic } from '../../models/land-logistic';
import { Response } from '../../models/response';

@Injectable({
  providedIn: 'root'
})
export class HttpLandLogisticsService {
  private serverUrl = environment.serverUrl;

  constructor(private httpClient: HttpClient) { }
  
  getAll(): Observable<Response<LandLogistic[]>> {
    return this.httpClient.get<Response<LandLogistic[]>>(`${this.serverUrl}/landLogistics`);
  }
  
  post(info: LandLogistic): Observable<Response<boolean>> {
    return this.httpClient.post<Response<boolean>>(`${this.serverUrl}/landLogistics`, info);
  }
  
  get(id: number): Observable<Response<LandLogistic>> {
    return this.httpClient.get<Response<LandLogistic>>(`${this.serverUrl}/landLogistics/${id}`);
  }
  
  put(id: number, info: LandLogistic): Observable<Response<boolean>> {
    return this.httpClient.put<Response<boolean>>(`${this.serverUrl}/landLogistics/${id}`, info);
  }
  
  delete(id: number): Observable<Response<boolean>> {
    return this.httpClient.delete<Response<boolean>>(`${this.serverUrl}/landLogistics/${id}`);
  }
}
