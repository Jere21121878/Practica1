import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddProdictComponent } from './add-prodict.component';

describe('AddProdictComponent', () => {
  let component: AddProdictComponent;
  let fixture: ComponentFixture<AddProdictComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddProdictComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddProdictComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
