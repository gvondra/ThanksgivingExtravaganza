import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MenuComponent } from './menu/menu.component';
import { HomeComponent } from './home/home.component';
import { SponsorComponent } from './sponsor/sponsor.component';
import { DisclaimerComponent } from './disclaimer/disclaimer.component';
import { FoodComponent } from './food/food.component';
import { FoodMenuItemComponent } from './food-menu-item/food-menu-item.component';
import { PhotosComponent } from './photos/photos.component';
import { InvitationComponent } from './invitation/invitation.component';
import { InvitationRsvpComponent } from './invitation-rsvp/invitation-rsvp.component';
import { InvitationsComponent } from './invitations/invitations.component';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    HomeComponent,
    SponsorComponent,
    DisclaimerComponent,
    FoodComponent,
    FoodMenuItemComponent,
    PhotosComponent,
    InvitationComponent,
    InvitationRsvpComponent,
    InvitationsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
