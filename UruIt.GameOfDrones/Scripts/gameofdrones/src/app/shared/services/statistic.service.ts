import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Statistic } from '../models/statistic';
import { Constants } from 'src/app/app.constants';
import { ErrorHandleService } from './error-handle';
import { Observable } from "rxjs";
import { catchError } from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class StatisticService {

  constructor(private http: HttpClient, private errorHandleService: ErrorHandleService) { }

  getStatistics(): Observable<Statistic[]> {
    //const uri = decodeURIComponent(`${Constants.statisticAPIUrl}` + 'GetStatistic');
    const uri = decodeURIComponent(`${Constants.statisticAPIUrl}`);
    return this.http.get<Statistic[]>(uri)
      .pipe(
        catchError(this.errorHandleService.handleError('getCountries', []))
      );
  }

  saveStatistic(player: string): Observable<any> {
    const uri = decodeURIComponent(`${Constants.statisticAPIUrl}`);
    const data = { Id: 0, PlayerName: player, WonGames: 0 };
    return this.http.post(uri, data);
  }
}
