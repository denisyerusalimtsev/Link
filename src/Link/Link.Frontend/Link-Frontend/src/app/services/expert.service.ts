import { HttpHeaders, HttpClient } from '@angular/common/http';
import { ExpertDto } from '../interfaces/expert-dto';
import { Expert } from '../models/expert';
import { Injectable } from '@angular/core';

@Injectable()
export class ExpertService {
    constructor(private http: HttpClient) { }
    baseUrl = 'http://localhost:50001/api/Expert/';

    getExperts() {
        return this.http.get<ExpertDto[]>(this.baseUrl);
    }

    getExpertById(id: number) {
        return this.http.get<ExpertDto>(this.baseUrl + '/' + id);
    }

    createExpert(expert: Expert) {
        return this.http.post(this.baseUrl, expert,
            {
                headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
                responseType: 'text'
            })
            .subscribe(data => console.log('Works!'));
    }

    updateExpert(expert: ExpertDto) {
        return this.http.put(this.baseUrl + '/' + expert.id, expert);
    }

    deleteExpert(id: number) {
        return this.http.delete(this.baseUrl + '/' + id);
    }
}
