import { Injectable } from '@angular/core';
import { HttpProductTypesService } from './http/http-product-type.service';
import { ProductType } from '../models/product-type';
import { Response } from '../models/response';
import { lastValueFrom, Observable } from 'rxjs';
import { Select } from '../models/select';

@Injectable({
  providedIn: 'root'
})
export class ProductTypeService {

  constructor(private httpProductTypesService: HttpProductTypesService) { }

  addProductType(name: string): Observable<Response<boolean>> {
    const info: ProductType = {
      productTypeId: 0,
      name: name
    };
    return this.httpProductTypesService.post(info);
  }

  updateProductType(productTypeId: number, name: string): Observable<Response<boolean>> {
    const info: ProductType = {
      productTypeId: productTypeId,
      name: name
    };
    return this.httpProductTypesService.put(productTypeId, info);
  }

  deleteProductType(productTypeId: number): Observable<Response<boolean>> {
    return this.httpProductTypesService.delete(productTypeId);
  }

  async getProductTypes(): Promise<Response<ProductType[]>> {
    const response = await lastValueFrom(this.httpProductTypesService.getAll());
    return response;
  }

  async getDataForSelect(): Promise<Select[]> {
    const response = await lastValueFrom(this.httpProductTypesService.getAll());
    return response.data.map(item => ({
      value: item.productTypeId,
      text: item.name
    }));
  }

}
