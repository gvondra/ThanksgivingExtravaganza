import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DisclaimerComponent } from './disclaimer/disclaimer.component';
import { FoodMenuItemComponent } from './food-menu-item/food-menu-item.component';
import { FoodComponent } from './food/food.component';
import { HomeComponent } from './home/home.component';
import { InvitationRsvpComponent } from './invitation-rsvp/invitation-rsvp.component';
import { InvitationComponent } from './invitation/invitation.component';
import { InvitationsComponent } from './invitations/invitations.component';
import { PhotosComponent } from './photos/photos.component';
import { SponsorComponent } from './sponsor/sponsor.component';

const routes: Routes = [
  {
    path: "",
    component: HomeComponent
  },
  {
    path: "sponsor",
    component: SponsorComponent
  },
  {
    path: "disclaimer",
    component: DisclaimerComponent
  },
  {
    path: "menu",
    component: FoodComponent
  },
  {
    path: "menuItem",
    component: FoodMenuItemComponent
  },
  {
    path: "menuItem/:id",
    component: FoodMenuItemComponent
  },
  {
    path: "photos",
    component: PhotosComponent
  },
  {
    path: "invitations",
    component: InvitationsComponent
  },
  {
    path: "invitation",
    component: InvitationComponent
  },
  {
    path: "invitation/:id",
    component: InvitationComponent
  },
  {
    path: "invitationrsvp/:id",
    component: InvitationRsvpComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
