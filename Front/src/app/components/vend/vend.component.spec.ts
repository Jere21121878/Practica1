import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VendComponent } from './vend.component';

describe('VendComponent', () => {
  let component: VendComponent;
  let fixture: ComponentFixture<VendComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VendComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VendComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
