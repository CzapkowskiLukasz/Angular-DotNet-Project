import { Component, Input, OnInit, ViewEncapsulation } from '@angular/core';
import { Address } from 'src/app/shared/models/address';

import SwiperCore, {
  Navigation,
  Pagination,
  Scrollbar,
  A11y,
  Virtual,
  Zoom,
  Autoplay,
  Thumbs,
  Controller,
  EffectCoverflow,
  SwiperOptions
} from "swiper";

// install Swiper components
SwiperCore.use([
  Navigation,
  Pagination,
  Scrollbar,
  A11y,
  Virtual,
  Zoom,
  Autoplay,
  Thumbs,
  Controller
]);

// install Swiper modules
SwiperCore.use([EffectCoverflow, Pagination]);

@Component({
  selector: 'app-address-swiper',
  templateUrl: './address-swiper.component.html',
  styleUrls: ['./address-swiper.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class AddressSwiperComponent implements OnInit {

  @Input() items: Address[] = [];
  
  constructor() { }

  ngOnInit(): void {
  }

  config: SwiperOptions = {
    loop: true,
    slidesPerView: 1,
    centeredSlides: true,
    autoplay: false,
    navigation: true
  }
}
