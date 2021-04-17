import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BookstoreDetailsComponent } from './bookstore-details.component';

describe('BookstoreDetailsComponent', () => {
  let component: BookstoreDetailsComponent;
  let fixture: ComponentFixture<BookstoreDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BookstoreDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BookstoreDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
