import { Component, ViewEncapsulation } from '@angular/core';
import { ComponentConnectionService } from 'src/app/core/componentConnection/component-connection.service';
import { RegisterRequest } from 'src/app/shared/models/register-request';
import { Router } from '@angular/router';
import { RegisterBase } from '../register-base';


@Component({
  selector: 'app-register-step1',
  templateUrl: './register-step1.component.html',
  styleUrls: ['./register-step1.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class RegisterStep1Component extends RegisterBase {

  constructor(protected componentConnection: ComponentConnectionService,
    protected router: Router) {
    super(componentConnection, router);
  }

  get languageId() {
    if (!this.registerRequest) {
      this.registerRequest = new RegisterRequest();
    }

    return this.registerRequest.languageId;
  }

  selectPolish() {
    this.registerRequest.languageId = 1;
  }

  selectEnglish() {
    this.registerRequest.languageId = 2;
  }

  // next() {
  //   super.next(2);
  // }
}