import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminDashboardComponent } from './modules/admin/admin-dashboard/admin-dashboard.component';
import { AdminProductCreateComponent } from './modules/admin/product/admin-product-create/admin-product-create.component';
import { AdminProductListComponent } from './modules/admin/product/admin-product-list/admin-product-list.component';
import { CartCheckoutComponent } from './modules/cart/cart-checkout/cart-checkout.component';
import { HomeComponent } from './modules/home/home.component';
import { CategoriesComponent } from './modules/product/categories/categories.component';
import { LoginComponent } from './modules/user/login/login/login.component';
import { ProfileComponent } from './modules/user/profile/profile.component';
import { RegisterStep1Component } from './modules/user/register/register-step1/register-step1.component';
import { RegisterStep2Component } from './modules/user/register/register-step2/register-step2.component';
import { RegisterStep3Component } from './modules/user/register/register-step3/register-step3.component';
import { RegisterStep4Component } from './modules/user/register/register-step4/register-step4.component';


const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterStep1Component },
  { path: 'register/step2', component: RegisterStep2Component },
  { path: 'register/step3', component: RegisterStep3Component },
  { path: 'register/step4', component: RegisterStep4Component },
  { path: 'profile', component: ProfileComponent },
  { path: 'admin/dashboard', component: AdminDashboardComponent },
  { path: 'admin/products', component: AdminProductListComponent },
  { path: 'admin/products/new-product', component: AdminProductCreateComponent },
  { path: 'categories', component: CategoriesComponent },
  { path: 'cart/checkout', component: CartCheckoutComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
