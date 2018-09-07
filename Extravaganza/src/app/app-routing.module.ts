import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuardService as AuthGuard } from './auth-guard.service';
import { HomeComponent } from './home/home.component';
import { SponsorComponent } from './sponsor/sponsor.component';
import { DisclaimerComponent } from './disclaimer/disclaimer.component';
import { FoodComponent} from './food/food.component';
import { PhotosComponent } from './photos/photos.component';
import { CallbackComponent } from './callback/callback.component';
import { FoodMenuItemComponent } from './food-menu-item/food-menu-item.component';
const routes: Routes = [
  {
    path: "",
    component: HomeComponent
  },
  {
    path: "callback",
    component: CallbackComponent
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
    component: FoodMenuItemComponent,
    canActivate: [AuthGuard]
  },
  {
    path: "menuItem/:id",
    component: FoodMenuItemComponent,
    canActivate: [AuthGuard]
  },
  {
    path: "photos",
    component: PhotosComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: [AuthGuard]
})
export class AppRoutingModule { }
