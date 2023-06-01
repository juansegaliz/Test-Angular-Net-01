import { Injectable } from '@angular/core';
import { HttpMaritimeLogisticsService } from './http/http-maritime-logistics.service';
import { MaritimeLogistic } from '../models/maritime-logistic';
import { Response } from '../models/response';
import { lastValueFrom, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class MaritimeLogisticService {
  constructor(private httpMaritimeLogisticsService: HttpMaritimeLogisticsService) {}

  addMaritimeLogistic(
    productTypeId: number,
    quantity: number,
    registrationDate: Date,
    deliveryDate: Date,
    portId: number,
    shippingPrice: number,
    fleetNumber: string,
    guideNumber: string,
    clientId: number
  ): Observable<Response<boolean>> {
    const info: MaritimeLogistic = {
      maritimeLogisticsId: 0,
      productTypeId: productTypeId,
      quantity: quantity,
      registrationDate: registrationDate,
      deliveryDate: deliveryDate,
      portId: portId,
      shippingPrice: shippingPrice,
      discount: 0,
      totalPrice: 0,
      fleetNumber: fleetNumber,
      guideNumber: guideNumber,
      clientId: clientId,
    };
    return this.httpMaritimeLogisticsService.post(info);
  }

  updateMaritimeLogistic(
    maritimeLogisticsId: number,
    productTypeId: number,
    quantity: number,
    registrationDate: Date,
    deliveryDate: Date,
    portId: number,
    shippingPrice: number,
    fleetNumber: string,
    guideNumber: string,
    clientId: number
  ): Observable<Response<boolean>> {
    const info: MaritimeLogistic = {
      maritimeLogisticsId: maritimeLogisticsId,
      productTypeId: productTypeId,
      quantity: quantity,
      registrationDate: registrationDate,
      deliveryDate: deliveryDate,
      portId: portId,
      shippingPrice: shippingPrice,
      discount: 0,
      totalPrice: 0,
      fleetNumber: fleetNumber,
      guideNumber: guideNumber,
      clientId: clientId,
    };
    return this.httpMaritimeLogisticsService.put(maritimeLogisticsId, info);
  }

  deleteMaritimeLogistic(maritimeLogisticsId: number): Observable<Response<boolean>> {
    return this.httpMaritimeLogisticsService.delete(maritimeLogisticsId);
  }

  async getMaritimeLogistics(): Promise<Response<MaritimeLogistic[]>> {
    const response = await lastValueFrom(
      this.httpMaritimeLogisticsService.getAll()
    );
    return response;
  }
}
