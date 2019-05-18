import { Component, OnInit, ViewChild, ElementRef, Inject } from '@angular/core';
import { DOCUMENT } from '@angular/common';
import { environment } from 'src/environments/environment';
import { StateService } from 'src/app/services/state.service';
declare var google: any;

@Component({
  selector: 'app-google-map',
  templateUrl: './google-map.component.html',
  styleUrls: ['./google-map.component.scss']
})
export class GoogleMapComponent implements OnInit {

  @ViewChild('mapRef') mapRef: ElementRef;
  constructor(@Inject(DOCUMENT) private document,
              private elementRef: ElementRef,
              private stateService: StateService) {
  }

  // tslint:disable-next-line:use-life-cycle-interface
  ngAfterViewInit() {
    const s = this.document.createElement('script');
    s.type = 'text/javascript';
    s.src = 'https://maps.googleapis.com/maps/api/js?key=' + environment.apiKey;
    this.elementRef.nativeElement.appendChild(s);
  }

  ngOnInit() {
    const self = this;
    // tslint:disable-next-line:only-arrow-functions
    setTimeout(function() {
      self.showMap();
    }, 2000);
  }

  showMap() {

    this.stateService.currentPlaceGeometry.subscribe(copter => {
      let point;
      if (copter) {
        point = new google.maps.LatLng(copter.latitude, copter.longitude);
      } else {
        point = new google.maps.LatLng(50.00566244, 36.22920255);
      }
      const mapOptions = {
        center: point,
        zoom: 15,
        mapTypeId: google.maps.MapTypeId.ROADMAP
      };

      const map = new google.maps.Map(this.mapRef.nativeElement, mapOptions);

      const marker = new google.maps.Marker({
        position: point,
        map
      });
    });
  }
}
