/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { AutoresComponent } from './Autores.component';

describe('AutoresComponent', () => {
  let component: AutoresComponent;
  let fixture: ComponentFixture<AutoresComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AutoresComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AutoresComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
