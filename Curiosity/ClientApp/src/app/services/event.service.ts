import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';
import { Injectable } from '@angular/core';
import { IPlan } from '../interfaces/iplan';

@Injectable({
  providedIn: 'root'
})
export class EventService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }
  getBevs(): Promise<IPlan[]> {
    return this.http.get<IPlan[]>(`${this.baseUrl}hotbevs`).toPromise();
  }
}
