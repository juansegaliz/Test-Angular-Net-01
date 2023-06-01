import { Injectable } from '@angular/core';
import { HttpLandLogisticsService } from './http/http-land-logistics.service';
import { LandLogistic } from '../models/land-logistic';
import { Response } from '../models/response';
import { lastValueFrom, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class LandLogisticService {
  constructor(private httpLandLogisticsService: HttpLandLogisticsService) {}

  addLandLogistic(
    productTypeId: number,
    quantity: number,
    registrationDate: Date,
    deliveryDate: Date,
    warehouseId: number,
    shippingPrice: number,
    vehiclePlate: string,
    guideNumber: string,
    clientId: number
  ): Observable<Response<boolean>> {
    const info: LandLogistic = {
      landLogisticsId: 0,
      productTypeId: productTypeId,
      quantity: quantity,
      registrationDate: registrationDate,
      deliveryDate: deliveryDate,
      warehouseId: warehouseId,
      shippingPrice: shippingPrice,
      discount: 0,
      totalPrice: 0,
      vehiclePlate: vehiclePlate,
      guideNumber: guideNumber,
      clientId: clientId,
    };
    return this.httpLandLogisticsService.post(info);
  }

  updateLandLogistic(
    landLogisticsId: number,
    productTypeId: number,
    quantity: number,
    registrationDate: Date,
    deliveryDate: Date,
    warehouseId: number,
    shippingPrice: number,
    vehiclePlate: string,
    guideNumber: string,
    clientId: number
  ): Observable<Response<boolean>> {
    const info: LandLogistic = {
      landLogisticsId: landLogisticsId,
      productTypeId: productTypeId,
      quantity: quantity,
      registrationDate: registrationDate,
      deliveryDate: deliveryDate,
      warehouseId: warehouseId,
      shippingPrice: shippingPrice,
      discount: 0,
      totalPrice: 0,
      vehiclePlate: vehiclePlate,
      guideNumber: guideNumber,
      clientId: clientId,
    };
    return this.httpLandLogisticsService.put(landLogisticsId, info);
  }

  deleteLandLogistic(landLogisticsId: number): Observable<Response<boolean>> {
    return this.httpLandLogisticsService.delete(landLogisticsId);
  }

  async getLandLogistics(): Promise<Response<LandLogistic[]>> {
    const response = await lastValueFrom(
      this.httpLandLogisticsService.getAll()
    );
    return response;
  }
}
