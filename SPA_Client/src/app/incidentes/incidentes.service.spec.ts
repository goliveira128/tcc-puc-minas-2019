import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ConfigService } from '../shared/config.service';

import { IncidentesService } from './incidentes.service';

describe('IncidentesModuleService', () => {
  beforeEach(() => TestBed.configureTestingModule({

    imports: [HttpClientTestingModule],
    providers: [ ConfigService ]
  }));

  it('should be created', () => {
    const service: IncidentesService = TestBed.get(IncidentesService);
    expect(service).toBeTruthy();
  });
});
