import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LandingPageComponent } from 'src/landing-page/landing-page.component';
import { LoginComponent } from './login/login.component';
import { PaymentComponent } from './payment/payment.component';
import { SportrocksComponent } from './sportrocks/sportrocks.component';

const routes: Routes = [
 // { path: '', redirectTo: '/landing-page', pathMatch: 'full' },
  { path: '', redirectTo: '/sportrocks', pathMatch: 'full' },
  { path: 'home', component: LandingPageComponent },
  { path: 'login', component: LoginComponent },
  { path: 'payment', component: PaymentComponent }, // Handle success
  { path: 'cancel', component: LandingPageComponent },
  { path: 'success', component: LandingPageComponent },
  { path: 'sportrocks', component: SportrocksComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
