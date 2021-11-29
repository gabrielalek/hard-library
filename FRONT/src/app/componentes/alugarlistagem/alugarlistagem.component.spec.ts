import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AlugarlistagemComponent } from './alugarlistagem.component';

describe('AlugarlistagemComponent', () => {
  let component: AlugarlistagemComponent;
  let fixture: ComponentFixture<AlugarlistagemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AlugarlistagemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AlugarlistagemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
