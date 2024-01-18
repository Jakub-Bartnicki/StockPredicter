import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, of } from 'rxjs';
import StocksDetails from './interfaces/stocksDetails';

@Injectable({
  providedIn: 'root'
})
export class StockApiService {
  stockApiUrl: string = "https://localhost:5001/";
  options: any = { }

  constructor(private httpClient: HttpClient) { }

  public getOne() : Observable<StocksDetails> {
    return this.httpClient.get<StocksDetails>(this.stockApiUrl + "Stock/search/x")
            .pipe(catchError(this.handleError<StocksDetails>('getStocksdetailsByName')));
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
  
      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead
  
      // TODO: better job of transforming error for user consumption
      // this.log(`${operation} failed: ${error.message}`);
  
      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
