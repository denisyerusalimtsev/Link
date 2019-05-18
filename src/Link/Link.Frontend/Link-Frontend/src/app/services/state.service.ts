import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Event } from '../models/event';


@Injectable()
export class StateService {

  public currentPlaceGeometry: BehaviorSubject<Event> = new BehaviorSubject(null);
  constructor() { }
}
