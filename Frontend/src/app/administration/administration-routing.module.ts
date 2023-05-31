import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { WarehousesComponent } from './warehouses/warehouses.component';
import { PortsComponent } from './ports/ports.component';

const routes: Routes = [
  {
    path: 'warehouses',
    component: WarehousesComponent
  },
  {
    path: 'ports',
    component: PortsComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdministrationRoutingModule { }
