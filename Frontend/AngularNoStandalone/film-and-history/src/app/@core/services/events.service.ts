import { HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Events } from '../../models/Events';

@Injectable({
  providedIn: 'root'
})
export class EventsService {
  url = 'https://api.api-ninjas.com/v1/historicalevents?text=';
  apiKey = `ArLzwVWQWBXNkPQVZvg0Gg==cQcappSk6FOqtkYF`;

  httpHeaders : HttpHeaders = new HttpHeaders({
    'X-Api-Key': 'HEPf1fkE8Jxa81Sley8K1Q==rvnX1ZNOLMWspa90'
  });

  constructor(private http: HttpClient) { }

  getEventByYear(releaseDate: any) {
    return  this.http.get<Events>
    (this.url, {params: { year: releaseDate.year, month: releaseDate.month}, headers: this.httpHeaders});
  }
}
