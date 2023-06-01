import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { WarehousesComponent } from './warehouses/warehouses.component';
import { PortsComponent } from './ports/ports.component';
import { ProductTypesComponent } from './producttypes/product-types.component';
import { ClientsComponent } from './clients/clients.component';
import { LandLogisticsComponent } from './landlogistics/land-logistics.component';
import { MaritimeLogisticsComponent } from './maritimelogistics/maritime-logistics.component';

const routes: Routes = [
  {
    path: 'warehouses',
    component: WarehousesComponent
  },
  {
    path: 'ports',
    component: PortsComponent
  },
  {
    path: 'producttypes',
    component: ProductTypesComponent
  },
  {
    path: 'clients',
    component: ClientsComponent
  },
  {
    path: 'landlogistics',
    component: LandLogisticsComponent
  },
  {
    path: 'maritimelogistics',
    component: MaritimeLogisticsComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdministrationRoutingModule { }
