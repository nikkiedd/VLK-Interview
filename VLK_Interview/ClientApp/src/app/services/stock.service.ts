import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Guid } from 'guid-typescript';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StockService {

  http: HttpClient;
  baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
  }

  getStockId(): Observable<Guid> {
    return this.http.get<Guid>(this.baseUrl + 'stock/Apple');
  }

  getStockPrice(stockId: Guid): Observable<number> {
    return this.http.get<number>(this.baseUrl + 'stock/' + stockId);
  }
}
