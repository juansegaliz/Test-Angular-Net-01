export interface MaritimeLogistic {
    maritimeLogisticsId: number;
    productTypeId: number;
    quantity: number;
    registrationDate: Date;
    deliveryDate: Date;
    portId: number;
    shippingPrice: number;
    discount: number;
    totalPrice: number;
    fleetNumber: string;
    guideNumber: string;
    clientId: number;
}