import { Guid } from 'guid-typescript';

export class Transaction {
  clientId: Guid;
  stockId: Guid;
  numberOfStocks: number;

  constructor(clientId: Guid, stockId: Guid, numberOfStocks: number) {
    this.clientId = clientId;
    this.stockId = stockId;
    this.numberOfStocks = numberOfStocks;
  }

}
