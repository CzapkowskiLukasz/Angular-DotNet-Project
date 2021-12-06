import { Component, Input, OnInit, ViewEncapsulation } from '@angular/core';

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
import { SlideItem } from '../../models/slide-item';

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

  @Input() items: SlideItem[] = [];

  constructor() { }

  ngOnInit(): void {
  }

  config: SwiperOptions = {
    loop: true,
    slidesPerView: 'auto',
    spaceBetween: 10,
    centeredSlides: true,
    autoplay: { delay: 1000, disableOnInteraction: false, pauseOnMouseEnter: true },
    speed: 3000,
    effect: 'coverflow',
    coverflowEffect: {
      rotate: 20,
      slideShadows: false,
    },
  }

  onCheckout(id) {
    console.log(`id produktu = ${id}`);
  }
}
