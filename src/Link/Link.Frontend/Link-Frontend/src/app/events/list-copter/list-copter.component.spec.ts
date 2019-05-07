import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListCopterComponent } from './list-copter.component';

describe('ListCopterComponent', () => {
  let component: ListCopterComponent;
  let fixture: ComponentFixture<ListCopterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListCopterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListCopterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
