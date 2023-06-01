export interface LandLogistic {
    landLogisticsId: number;
    productTypeId: number;
    quantity: number;
    registrationDate: Date;
    deliveryDate: Date;
    warehouseId: number;
    shippingPrice: number;
    discount: number;
    totalPrice: number;
    vehiclePlate: string;
    guideNumber: string;
    clientId: number;
}