import { Component } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { AccountService } from './services/account.service';
import { ClientAccount } from './models/client-account.model';
import { Guid } from 'guid-typescript';
import { ReactiveFormsModule } from '@angular/forms';
import { StockService } from './services/stock.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css', '../styles.css']
})
export class AppComponent {
  title = 'app';

  buyingForm = this.formBuilder.group({
    stocksNumber: new FormControl("", [Validators.required]),
  });
  account: ClientAccount = { id: Guid.createEmpty(), name: "", balance: 0 };
  stockId: Guid = Guid.createEmpty();
  accountService: AccountService;
  stockService: StockService;

  constructor(private formBuilder: FormBuilder, accountService: AccountService, stockService: StockService) {
    this.accountService = accountService;
    this.stockService = stockService;
  }

  ngOnInit(): void {
    this.getAccountDetails();
    this.getStockId();
  }

  getAccountDetails() {
    this.accountService.getAccount().subscribe(response => {
      this.account = response;
    }
    );
  }

  getStockId() {
    this.stockService.getStockId().subscribe(response => {
      this.stockId = response;
    });
  }

  onSubmit(): void {
    // process checkout data here
    var requestedStocks = this.buyingForm.get('stocksNumber')?.value;
    console.log(requestedStocks);
    this.stockService.getStockPrice(this.stockId).subscribe(response => {
      var stockPrice = response;
      var value = stockPrice * requestedStocks;
      // check if user has enough money
      var balance = this.account.balance;
      if (balance < value) { // inform user that they do not have enough money
        alert(`Balance too low for this transaction. You need to have at least ${value} dollars`);
      }
      else { // ask user if they want to proceed
        if (confirm(`Are you sure you want to buy ${requestedStocks} stocks worth ${value} dollars?`)) {
          this.placeOrder(requestedStocks);
          this.buyingForm.reset();
        }
      }
    },
      (error) => {
        alert("Could not compute total value of the stocks. Please try again.");
      });
  }

  placeOrder(requestedStocks: number) {
    this.accountService.placeOrder(this.account.id, this.stockId, requestedStocks).subscribe(response => {
      this.account.balance = response;
    });
  }
}
