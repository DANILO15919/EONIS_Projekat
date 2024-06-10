import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SportrocksComponent } from './sportrocks.component';

describe('SportrocksComponent', () => {
  let component: SportrocksComponent;
  let fixture: ComponentFixture<SportrocksComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SportrocksComponent]
    });
    fixture = TestBed.createComponent(SportrocksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
