import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Speaker } from './speaker';

describe('Speaker', () => {
  let component: Speaker;
  let fixture: ComponentFixture<Speaker>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Speaker]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Speaker);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
