import { HttpHeaders, HttpClient } from '@angular/common/http';
import { EventDto } from '../interfaces/event-dto';

export class EventService {
    constructor(private http: HttpClient) { }
    baseUrl = 'http://localhost:50001/api/Event/';

    getEvents() {
        return this.http.get<EventDto[]>(this.baseUrl);
    }

    getEventById(id: number) {
        return this.http.get<EventDto>(this.baseUrl + '/' + id);
    }

    createEvent(event: EventDto) {
        return this.http.post(this.baseUrl, event,
            {
                headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
                responseType: 'text'
            })
            .subscribe(data => console.log('Works!'));
    }

    updateEvent(event: EventDto) {
        return this.http.put(this.baseUrl + '/' + event.id, event);
    }

    deleteEvent(id: number) {
        return this.http.delete(this.baseUrl + '/' + id);
    }
}