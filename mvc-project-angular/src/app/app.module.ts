import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { HomeComponent } from './modules/home/home.component';
import { RegisterStep1Component } from './modules/user/register/register-step1/register-step1.component';
import { RegisterStep2Component } from './modules/user/register/register-step2/register-step2.component';
import { RegisterStep3Component } from './modules/user/register/register-step3/register-step3.component';
import { RegisterStep4Component } from './modules/user/register/register-step4/register-step4.component';
import { LoginComponent } from './modules/user/login/login/login.component';
import { ProfileComponent } from './modules/user/profile/profile.component';

@NgModule({
  declarations: [
    AppComponent,
    RegisterStep1Component,
    HomeComponent,
    RegisterStep2Component,
    RegisterStep3Component,
    RegisterStep4Component,
    LoginComponent,
    ProfileComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
