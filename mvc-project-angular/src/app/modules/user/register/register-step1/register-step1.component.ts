import { Component, ViewEncapsulation } from '@angular/core';
import { ComponentConnectionService } from 'src/app/core/componentConnection/component-connection.service';
import { RegisterRequest } from 'src/app/shared/models/register-request';
import { Router } from '@angular/router';
import { RegisterBase } from '../register-base';
import { UserService } from 'src/app/core/user/user.service';


@Component({
  selector: 'app-register-step1',
  templateUrl: './register-step1.component.html',
  styleUrls: ['./register-step1.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class RegisterStep1Component extends RegisterBase {

  constructor(protected componentConnection: ComponentConnectionService,
    protected router: Router,
    private userService: UserService) {
    super(componentConnection, router);
  }

  get languageId() {
    return this.registerRequest.languageId;
  }

  selectPolish() {
    this.registerRequest.languageId = 1;
  }

  selectEnglish() {
    this.registerRequest.languageId = 2;
  }

  protected requestIsValid() {
    return !this.userService.isLogged();
  }

  protected prepareView() {
    if (!this.registerRequest)
      this.registerRequest = new RegisterRequest();
  }
  protected invalidRequestMove() {
    this.router.navigate(['']);
  }
}