import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';

import { AppComponent } from './app.component';
import { HomeComponent } from './modules/home/home.component';
import { RegisterStep1Component } from './modules/user/register/register-step1/register-step1.component';
import { RegisterStep2Component } from './modules/user/register/register-step2/register-step2.component';
import { RegisterStep3Component } from './modules/user/register/register-step3/register-step3.component';
import { RegisterStep4Component } from './modules/user/register/register-step4/register-step4.component';
import { LoginComponent } from './modules/user/login/login/login.component';
import { ProfileComponent } from './modules/user/profile/profile.component';
import { AdminDashboardComponent } from './modules/admin/admin-dashboard/admin-dashboard.component';
import { AdminProductListComponent } from './modules/admin/product/admin-product-list/admin-product-list.component';
import { AdminProductCreateComponent } from './modules/admin/product/admin-product-create/admin-product-create.component';
import { ReactiveFormsModule } from '@angular/forms';
import { FilteredDropdownComponent } from './shared/modules/filtered-dropdown/filtered-dropdown.component';
import { SwiperModule } from "swiper/angular";
import { SwiperComponent } from './shared/modules/swiper/swiper.component';
import { SlideComponent } from './shared/modules/slide/slide.component';
import { NavbarComponent } from './shared/modules/navbar/navbar.component';
import { ChangeLanguageComponent } from './shared/modules/change-language/change-language.component';
import { AdminStatisticsComponent } from './modules/admin/admin-statistics/admin-statistics.component';
import { AdminDeleteConfirmComponent } from './modules/admin/admin-delete-confirm/admin-delete-confirm.component';
import { UserListComponent } from './modules/admin/user/user-list/user-list.component';
import { UserInfoComponent } from './modules/admin/user/user-info/user-info.component';
import { CategoriesComponent } from './modules/product/categories/categories.component';
import { UserVoucherComponent } from './modules/admin/user/user-voucher/user-voucher.component';
import { ProducersListComponent } from './modules/admin/producers/producers-list/producers-list.component';
import { CountryListComponent } from './modules/admin/countries/country-list/country-list.component';
import { DeliveryListComponent } from './modules/admin/delivery/delivery-list/delivery-list.component';
import { DiscountListComponent } from './modules/admin/discount/discount-list/discount-list.component';
import { ProducersAddComponent } from './modules/admin/producers/producers-add/producers-add.component';
import { CategoryListComponent } from './modules/admin/category/category-list/category-list.component';
import { CountryCreateComponent } from './modules/admin/countries/country-create/country-create.component';
import { CategoryCreateComponent } from './modules/admin/category/category-create/category-create.component';
import { CreateDiscountComponent } from './modules/admin/discount/create-discount/create-discount.component';
import { AddresComponent } from './shared/modules/address/addres/addres.component';
import { AddresCreateComponent } from './shared/modules/address/addres-create/addres-create.component';
import { CartCheckoutComponent } from './modules/cart/cart-checkout/cart-checkout.component';
import { CartElementComponent } from './shared/modules/cart-element/cart-element.component';
import { CartCheckoutElementComponent } from './shared/modules/cart-checkout-element/cart-checkout-element.component';
import { DeliveryOptionsComponent } from './shared/modules/delivery-options/delivery-options.component';
import { ProductDetailsComponent } from './modules/product/product-details/product-details.component';
import { ProductListComponent } from './modules/product/product-list/product-list.component';
import { ProductListElementComponent } from './modules/product/product-list-element/product-list-element.component';
import { ExpandFormComponent } from './modules/admin/shared/expand-form/expand-form.component';
import { OrderListComponent } from './modules/admin/user/order-list/order-list.component';
import { UserListElementComponent } from './modules/admin/user/user-list-element/user-list-element.component';
import { AuthInterceptor } from './core/authorization/auth.interceptor';
import { RegisterStep5Component } from './modules/user/register/register-step5/register-step5/register-step5.component';
import { AddressSlideComponent } from './shared/modules/address/address-slide/address-slide/address-slide.component';
import { AddressSwiperComponent } from './shared/modules/address/address-swiper/address-swiper/address-swiper.component';

export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http);
}

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
    AdminDashboardComponent,
    AdminProductListComponent,
    AdminProductCreateComponent,
    FilteredDropdownComponent,
    SwiperComponent,
    SlideComponent,
    NavbarComponent,
    ChangeLanguageComponent,
    AdminStatisticsComponent,
    AdminDeleteConfirmComponent,
    UserListComponent,
    UserInfoComponent,
    CategoriesComponent,
    UserVoucherComponent,
    ProducersListComponent,
    CountryListComponent,
    DeliveryListComponent,
    DiscountListComponent,
    ProducersAddComponent,
    CategoryListComponent,
    CountryCreateComponent,
    CategoryCreateComponent,
    CreateDiscountComponent,
    AddresComponent,
    AddresCreateComponent,
    CartCheckoutComponent,
    CartElementComponent,
    CartCheckoutElementComponent,
    DeliveryOptionsComponent,
    ProductDetailsComponent,
    ProductListComponent,
    ProductListElementComponent,
    ExpandFormComponent,
    OrderListComponent,
    UserListElementComponent,
    RegisterStep5Component,
    AddressSlideComponent,
    AddressSwiperComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    SwiperModule, 
    HttpClientModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient]
      }
    })
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
