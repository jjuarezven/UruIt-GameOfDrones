import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Statistic } from '../models/statistic';
import { Constants } from 'src/app/app.constants';

@Injectable({
  providedIn: 'root'
})
export class StatisticService {

  constructor(private http: HttpClient) { }

  getStatistics(): Observable<Statistic> {
    const uri = decodeURIComponent(`${Constants.statisticAPIUrl}`);
    return this.http.get<Statistic>(uri);
  }
}
