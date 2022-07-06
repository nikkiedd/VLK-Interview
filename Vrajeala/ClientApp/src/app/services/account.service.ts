import { HttpClient, HttpParams } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Guid } from 'guid-typescript';
import { Observable } from 'rxjs';
import { ClientAccount } from '../models/client-account.model';
import { Transaction } from '../models/transaction.model';


@Injectable({
  providedIn: 'root'
})
export class AccountService {

  http: HttpClient;
  baseUrl: string;
  clientAccount!: ClientAccount; 

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;

  }

  getAccount() : Observable<ClientAccount>{
    return this.http.get<ClientAccount>(this.baseUrl + "clientaccount");
  }

  getOrderValue(requestedStocks: number): Observable<number> {
    return this.http.get<number>(this.baseUrl + `stock/${requestedStocks}` );
  }


  placeOrder(clientId: Guid, stockId: Guid, requestedStocks: number): Observable<number> {
    var transaction: Transaction = { 'clientId': clientId, 'stockId': stockId, 'numberOfStocks': requestedStocks };
    return this.http.post<number>(this.baseUrl + 'stock', transaction);
  }


}
