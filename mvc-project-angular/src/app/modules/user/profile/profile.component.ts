import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { LocalTranslateService } from 'src/app/core/internationalization/local-translate.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class ProfileComponent implements OnInit {
  count: number;
  showCart: boolean;

  constructor(public translate: LocalTranslateService) {
    this.count = 0;
    this.showCart = false;
  }

  ngOnInit(): void {
  }

  increse() {
    this.count += 1;
  }
}
