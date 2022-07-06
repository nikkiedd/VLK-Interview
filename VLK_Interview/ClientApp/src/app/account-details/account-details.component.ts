import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { Guid } from 'guid-typescript';
import { AccountService } from '../services/account.service';
import { ClientAccount } from '../models/client-account.model';


@Component({
  selector: 'app-account-details',
  templateUrl: './account-details.component.html',
  styleUrls: ['./account-details.component.css']
})
export class AccountDetailsComponent implements OnInit {

  account: ClientAccount = {id:Guid.createEmpty(), name: "", balance: 0};
  accountService: AccountService;


  constructor(accountService: AccountService) {
    this.accountService = accountService;
   }


  ngOnInit(): void {
    this.getAccountDetails();
  }

  getAccountDetails() {
    this.accountService.getAccount().subscribe(response => {
      this.account = response;
    }
    );
  }

}
