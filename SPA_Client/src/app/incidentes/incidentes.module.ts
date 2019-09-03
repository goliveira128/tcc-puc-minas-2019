import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule }   from '../shared/shared.module';
import { IndexComponent } from './index/index.component';
import { CreateIncidenteComponent } from './create/create.component';
import { FormsModule } from '@angular/forms';
import { IncidentesService }  from '../incidentes/incidentes.service';

import { IncidentesRoutingModule } from './incidentes.routing-module';

@NgModule({
  declarations: [IndexComponent, CreateIncidenteComponent],
  providers: [ IncidentesService],
  imports: [
    CommonModule,  
    IncidentesRoutingModule,
    SharedModule,
    FormsModule
  ]
})
export class IncidentesModule { }
