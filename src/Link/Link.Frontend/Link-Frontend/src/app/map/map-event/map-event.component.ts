import { Component, OnInit } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Place } from 'src/app/models/place.model';

@Component({
  selector: 'app-map-event',
  templateUrl: './map-event.component.html',
  styleUrls: ['./map-event.component.scss']
})
export class MapEventComponent implements OnInit {
  actionName = 'Close';
  places: BehaviorSubject<Place[]> = new BehaviorSubject(null);
  constructor() { }

  ngOnInit() {
  }

  changeActionName() {
    if (this.actionName === 'Open') {
      this.actionName = 'Close';
    } else {
      this.actionName = 'Open';
    }
  }
}
