import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VerStoreComponent } from './ver-store.component';

describe('VerStoreComponent', () => {
  let component: VerStoreComponent;
  let fixture: ComponentFixture<VerStoreComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VerStoreComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VerStoreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
