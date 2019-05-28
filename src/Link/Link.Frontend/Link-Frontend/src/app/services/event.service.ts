import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { EventDto } from '../interfaces/event-dto';
import { Event } from '../models/event';
import { GetEventsDto } from '../dto/get-event.dto';

@Injectable()
export class EventService {
    constructor(private http: HttpClient) { }
    baseUrl = 'https://localhost:60005/api/events/';

    getEvents() {
        return this.http.get<GetEventsDto>(this.baseUrl);
    }

    getEventById(id: number) {
        return this.http.get<EventDto>(this.baseUrl + '/' + id);
    }

    createEvent(event: Event) {
        return this.http.post(this.baseUrl, event,
            {
                headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
                responseType: 'text'
            })
            .subscribe(data => console.log('Works!'));
    }

    updateEvent(event: Event) {
        return this.http.put(this.baseUrl + '/' + event.id, event);
    }

    deleteEvent(id: number) {
        return this.http.delete(this.baseUrl + '/' + id);
    }

    assignExperts(assignedExperts: AssignExpertsModel) {

    }
}
