import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { finalize } from 'rxjs/operators'
import { AuthService } from '../../core/authentication/auth.service';
import { IncidentesService } from '../incidentes.service';
import { Incidente } from "../../shared/models/incidentes";
import { Observable } from 'rxjs';
import { ActivatedRoute } from "@angular/router";


@Component({
  selector: 'app-create-incidente',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})

export class CreateIncidenteComponent implements OnInit {

  incidente: Incidente = new Incidente('','','',new Date(), '', '', '');
  submitted = false;
  busy: boolean;
  error:boolean;
  id: string;
  status = [];
  naoConformidades: any;
  acao: string;
  constructor(private authService: AuthService, private incidentesService: IncidentesService, private spinner: NgxSpinnerService, private route: ActivatedRoute) {
    this.status = [
      { value: 'Em Andamento', label: 'Em Andamento' },
      { value: 'Abertura', label: 'Abertura' },
      { value: 'Finalizado', label: 'Finalizado' }
    ];

    let userRole = this.authService.role;

    if (userRole === "operador") {
      this.status = this.status.filter(f => f.value != "Finalizado");
    }

    if (userRole === "administrador") {
      this.status = this.status.filter(f => f.value == "Finalizado");
    }

  }

  ngOnInit() {
    this.id = this.route.snapshot.paramMap.get("id");
    if (this.id != null) {
      this.spinner.show();
      this.incidentesService.fetchIncidenteData(this.authService.authorizationHeaderValue, this.authService.user.profile.sub, this.id)
        .pipe(finalize(() => {
          this.spinner.hide();
          this.busy = false;
        })).subscribe(
          result => {
            this.incidente = result as Incidente;
            console.log(this.incidente)
          });
    }

    this.incidentesService.fetchNaoConformidadesData(this.authService.authorizationHeaderValue, this.authService.user.profile.sub)
    .subscribe(
        result => {
          this.naoConformidades = result;
        });
    
  }

  novoIncidente(): void {
    this.submitted = false;
    this.incidente = new Incidente(null, '', '', new Date(), '', '', '');
  }

  insertIncidente() {

    if (this.id != null) {
      this.update();
    } else {
      this.add();
    }
  }


  update() {
    this.incidentesService.updateIncidentesData(this.authService.authorizationHeaderValue, this.incidente).pipe(finalize(() => {
        this.spinner.hide();
        this.busy = false;
      }))
      .subscribe(
        result => {
          if (result) {
            this.submitted = true;
            this.acao = "atualizado";
            this.spinner.hide();
          }
        },
        error => {
          console.log(error);
          this.error = true;
          this.spinner.hide();
        });;
  }

  add() {
    this.incidentesService.insertIncidentesData(this.authService.authorizationHeaderValue, this.incidente).pipe(finalize(() => {
        this.spinner.hide();
        this.busy = false;
      }))
      .subscribe(
        result => {
          if (result) {
            this.submitted = true;
            this.acao = "registrado";
            this.spinner.hide();
          }
        },
        error => {
          console.log(error);
          this.error = true;
          this.spinner.hide();
        });;
  }

  onSubmit() {
    
    this.busy = true;
    this.spinner.show();

    this.incidente.idusuario = this.authService.user.profile.sub;
    this.incidente.userid = this.authService.user.profile.sub;

    this.insertIncidente();
  }
  
}
