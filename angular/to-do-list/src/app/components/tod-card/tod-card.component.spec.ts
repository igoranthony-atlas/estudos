import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TodCardComponent } from './tod-card.component';

describe('TodCardComponent', () => {
  let component: TodCardComponent;
  let fixture: ComponentFixture<TodCardComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [TodCardComponent]
    });
    fixture = TestBed.createComponent(TodCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
