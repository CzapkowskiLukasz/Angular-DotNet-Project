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
import { AdminDashboardComponent } from './modules/admin/admin-dashboard/admin-dashboard.component';
import { AdminProductListComponent } from './modules/admin/product/admin-product-list/admin-product-list.component';
import { AdminProductCreateComponent } from './modules/admin/product/admin-product-create/admin-product-create.component';
import { ReactiveFormsModule } from '@angular/forms';
import { FilteredDropdownComponent } from './shared/modules/filtered-dropdown/filtered-dropdown.component';

@NgModule({
  declarations: [
    AppComponent,
    RegisterStep1Component,
    HomeComponent,
    RegisterStep2Component,
    RegisterStep3Component,
    RegisterStep4Component,
    LoginComponent,
    AdminDashboardComponent,
    AdminProductListComponent,
    AdminProductCreateComponent,
    FilteredDropdownComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
