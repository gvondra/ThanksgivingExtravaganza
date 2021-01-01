import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InvitationRsvpComponent } from './invitation-rsvp.component';

describe('InvitationRsvpComponent', () => {
  let component: InvitationRsvpComponent;
  let fixture: ComponentFixture<InvitationRsvpComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InvitationRsvpComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InvitationRsvpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
