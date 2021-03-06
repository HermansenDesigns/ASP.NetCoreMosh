import { Component, OnInit } from "@angular/core";
import { VehicleService } from "../../services/vehicle.service";

@Component({
  selector: "app-vehicle-form",
  templateUrl: "./vehicle-form.component.html",
  styleUrls: ["./vehicle-form.component.css"]
})
export class VehicleFormComponent implements OnInit {

  makes: any[];
  models: any[];
  features: any[];
  vehicle: any = {};

  constructor(
    private vehicleService: VehicleService) { }

  // tslint:disable-next-line:typedef
  ngOnInit() {
    this.vehicleService.getMakes().subscribe(makes =>
      this.makes = makes);

      this.vehicleService.getFeatures().subscribe(features =>
        this.features = features);
  }

  // tslint:disable-next-line:typedef
  onMakeChange() {
    // tslint:disable-next-line:typedef
    var selectedMake = this.makes.find(m => m.id == this.vehicle.makeId);
    this.models = selectedMake ? selectedMake.models : [];
  }
}
