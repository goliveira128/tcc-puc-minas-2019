import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders  } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { BaseService } from "../shared/base.service";
import { ConfigService } from '../shared/config.service';
import { Incidente  } from '../shared/models/incidentes';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})

export class IncidentesService extends BaseService {

  constructor(private http: HttpClient, private configService: ConfigService) {    
    super();      
  }

  insertIncidentesData(token: string, incidente: Incidente) {
    
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': token
      })
    };

    return this.http.post(this.configService.incidentesApiURI + '?userId=' + incidente.userid, incidente, httpOptions).pipe(catchError(this.handleError));
  }

  updateIncidentesData(token: string, incidente: Incidente) {

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': token
      })
    };

    console.log(incidente);
    return this.http.put(this.configService.incidentesApiURI + '?userId=' + incidente.userid, incidente, httpOptions).pipe(catchError(this.handleError));
  }

  fetchIncidentesData(token: string, userId: string) {

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': token
      })
    };

    return this.http.get(this.configService.incidentesApiURI + '/' + userId, httpOptions).pipe(catchError(this.handleError));
  }

  fetchNaoConformidadesData(token: string, userId: string) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': token
      })
    };

    return this.http.get(this.configService.naoConformidadesApiURI + '/' + userId, httpOptions).pipe(catchError(this.handleError));
  }

  fetchIncidenteData(token: string, userId: string, incidenteId: string ) {

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': token
      })
    };

    return this.http.get(this.configService.incidentesApiURI + '/' + userId + '/' + incidenteId, httpOptions).pipe(catchError(this.handleError));
  }

  deleteIncidente(incidenteId: string, token: string, userId: string) {

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': token
      })
    };

    return this.http.delete(this.configService.incidentesApiURI + '/' + userId + '/' + incidenteId, httpOptions).pipe(catchError(this.handleError));
  }
}
