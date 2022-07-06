import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';


import { AppComponent } from './app.component';
import { AccountDetailsComponent } from './account-details/account-details.component';
import { StockBuyerComponent } from './stock-buyer/stock-buyer.component';
import { AccountService } from './services/account.service';
import { AppRoutingModule } from './app-routing.module';
import { StockService } from './services/stock.service';

@NgModule({
  declarations: [
    AppComponent,
    AccountDetailsComponent,
    StockBuyerComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule
  ],
  providers: [AccountService, StockService],
  bootstrap: [AppComponent]
})
export class AppModule { }
