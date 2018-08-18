import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { SponsorComponent } from './sponsor/sponsor.component';
import { DisclaimerComponent } from './disclaimer/disclaimer.component';
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
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
