import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HotBevComponent } from './hot-bev.component';

describe('HotBevComponent', () => {
  let component: HotBevComponent;
  let fixture: ComponentFixture<HotBevComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HotBevComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HotBevComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
