import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class VehicleService {

  constructor(private http: Http) { }

  getMakes() {
    let result = this.http.get('/api/makes')
      .map(res => res.json());
    return result
  }

  getFeatures() {
    let result = this.http.get('/api/features')
    .map(res => res.json());
  return result
}

}
