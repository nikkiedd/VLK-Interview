import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StockBuyerComponent } from './stock-buyer.component';

describe('StockBuyerComponent', () => {
  let component: StockBuyerComponent;
  let fixture: ComponentFixture<StockBuyerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StockBuyerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StockBuyerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
