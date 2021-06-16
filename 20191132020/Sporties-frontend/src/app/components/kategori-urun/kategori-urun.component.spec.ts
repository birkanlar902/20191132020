/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { KategoriUrunComponent } from './kategori-urun.component';

describe('KategoriUrunComponent', () => {
  let component: KategoriUrunComponent;
  let fixture: ComponentFixture<KategoriUrunComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ KategoriUrunComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(KategoriUrunComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
