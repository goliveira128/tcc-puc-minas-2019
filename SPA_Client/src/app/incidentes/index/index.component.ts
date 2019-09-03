import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { finalize } from 'rxjs/operators'
import { AuthService } from '../../core/authentication/auth.service';
import { IncidentesService } from '../incidentes.service';
import { Incidente } from "../../shared/models/incidentes";
import { Observable } from 'rxjs';


@Component({
  selector: 'top-secret-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.scss']
})
export class IndexComponent implements OnInit {

  claims=null;
  busy: boolean;
  canDelete: boolean;
  canInsert: boolean;
  error: boolean;
  incidentesData: Observable<Incidente[]>;

  constructor(private authService: AuthService, private incidentesService: IncidentesService, private spinner: NgxSpinnerService) {
    let userRole = this.authService.role;

    if (userRole === "operador") {
      this.canDelete = false;
      this.canInsert = true;
    }

    if (userRole === "administrador") {
      this.canDelete = true;
      this.canInsert = false;
    }
  }
  

  deleteIncidente(id: string) {
    this.spinner.show();
    this.incidentesService.deleteIncidente(id, this.authService.authorizationHeaderValue, this.authService.user.profile.sub)
      .pipe(finalize(() => {
        this.spinner.hide();
        this.busy = false;
        this.error = true;
      })).subscribe(
        result => {
          console.log(result);
          this.reloadData();
        },
        error => {
          this.error = true;
        });
  }

  reloadData() {
    this.busy = true;
    this.spinner.show();
    this.incidentesService.fetchIncidentesData(this.authService.authorizationHeaderValue, this.authService.user.profile.sub)
      .pipe(finalize(() => {
        this.spinner.hide();
        this.busy = false;
      })).subscribe(
        result => {
          this.incidentesData = result as Observable<Incidente[]>;
        });
  }

  ngOnInit() {    
    this.reloadData();
  }
}
