import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { IHotBev } from '../interfaces/ihot-bev';

@Injectable({
  providedIn: 'root'
})
export class HotBevService {

  hotBevs: IHotBev[];

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getBevs(): Promise<IHotBev[]> {
    return this.http.get<IHotBev[]>(`${this.baseUrl}hotbevs`).toPromise();
  }

  async getBev(id: number): Promise<IHotBev> {
    return await this.http.get<IHotBev>(`${this.baseUrl}hotbevs/${id}` ).toPromise();
  }

  addBev(newBev: IHotBev): Promise<IHotBev> {
    return this.http.post<IHotBev>(`${this.baseUrl}hotbevs`, newBev).toPromise();
  }

  async updateBev(bevId: number, bev: IHotBev) {
    return await this.http.put<IHotBev>(`${this.baseUrl}hotbevs/${bevId}`, bev).toPromise();
  }

  async deleteBev(bevId: number) {
    return await this.http.delete<IHotBev>(`${this.baseUrl}hotbevs/${bevId}`).toPromise();
  }
}
