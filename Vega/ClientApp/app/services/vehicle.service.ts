import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import "rxjs/add/operator/map";

@Injectable()
export class VehicleService {

  constructor(private http: Http) { }

  // tslint:disable-next-line:typedef
  getMakes() {
    return this.http.get("/api/Makes")
      .map(res => res.json());
  }

  // tslint:disable-next-line:typedef
  getFeatures() {
    return this.http.get("/api/Features")
      .map(res => res.json());
  }
}
