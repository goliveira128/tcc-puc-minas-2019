import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { Shell } from './../shell/shell.service';
import { IndexComponent } from './index/index.component';
import { CreateIncidenteComponent } from './create/create.component';
import { AuthGuard } from '../core/authentication/auth.guard';

const routes: Routes = [
Shell.childRoutes([
    { path: 'incidentes', component: IndexComponent, canActivate: [AuthGuard] },
    { path: 'incidentes/insert', component: CreateIncidenteComponent, canActivate: [AuthGuard] },
    { path: 'incidentes/update/:id', component: CreateIncidenteComponent, canActivate: [AuthGuard] }      
  ])
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: []
})
export class IncidentesRoutingModule { }
