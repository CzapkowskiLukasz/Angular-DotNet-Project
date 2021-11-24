import { Component, OnInit, ViewEncapsulation } from '@angular/core';

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
  selector: 'app-swiper',
  templateUrl: './swiper.component.html',
  styleUrls: ['./swiper.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class SwiperComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  config: SwiperOptions = {
    loop: true,
    slidesPerView: 'auto',
    spaceBetween: 20,
    centeredSlides: true,
    autoplay: { delay: 60, disableOnInteraction: false, pauseOnMouseEnter: true },
    speed: 5000,
    effect: 'coverflow',
    coverflowEffect: {
      rotate: 20,
      slideShadows: false,
    },
  }

}
