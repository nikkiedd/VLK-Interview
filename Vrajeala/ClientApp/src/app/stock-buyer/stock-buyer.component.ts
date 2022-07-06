import { Component, OnInit } from '@angular/core';

import { FormBuilder } from '@angular/forms';
import { AccountService } from '../services/account.service';


@Component({
  selector: 'app-stock-buyer',
  templateUrl: './stock-buyer.component.html',
  styleUrls: ['./stock-buyer.component.css']
})
export class StockBuyerComponent implements OnInit {


  buyingForm = this.formBuilder.group({
    numberOfStocks: '',
  });

  accountService: AccountService;

  constructor(private formBuilder: FormBuilder, accountService: AccountService) { 
    this.accountService = accountService;
  }

  ngOnInit(): void {
  }

  onSubmit(): void {
    // Process checkout data here
    // var balance = accountService.getAccountBalance();
    console.warn('Your order has been submitted', this.buyingForm.value);
    this.buyingForm.reset();
  }

}
