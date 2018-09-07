import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { AuthService } from './auth.service';
import { AppRoutingModule } from './app-routing.module';
import { MarkdownToHtmlModule } from 'ng2-markdown-to-html';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { MenuComponent } from './menu/menu.component';
import { SponsorComponent } from './sponsor/sponsor.component';
import { DisclaimerComponent } from './disclaimer/disclaimer.component';
import { FoodComponent } from './food/food.component';
import { PhotosComponent } from './photos/photos.component';
import { CallbackComponent } from './callback/callback.component';
import { FoodMenuItemComponent } from './food-menu-item/food-menu-item.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    MenuComponent,
    SponsorComponent,
    DisclaimerComponent,
    FoodComponent,
    PhotosComponent,
    CallbackComponent,
    FoodMenuItemComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpModule,
    MarkdownToHtmlModule
  ],
  providers: [AuthService],
  bootstrap: [AppComponent]
})
export class AppModule { }
