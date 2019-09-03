import { Injectable } from '@angular/core';
 
@Injectable()
export class ConfigService {    

    constructor() {}

    get authApiURI() {
      return 'https://authserversgq.azurewebsites.net/api';
    }    
     
    get resourceApiURI() {
      return 'https://apigatewaysgq.azurewebsites.net/api/v1/incidentes';
    }

    get incidentesApiURI() {
      return 'https://apigatewaysgq.azurewebsites.net/api/v1/incidentes';
    }

    get naoConformidadesApiURI() {
      return 'https://apigatewaysgq.azurewebsites.net/api/v1/naoconformidade';
    }
}
