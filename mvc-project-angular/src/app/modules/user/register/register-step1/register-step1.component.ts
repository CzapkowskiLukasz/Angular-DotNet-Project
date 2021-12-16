import { Component, ViewEncapsulation } from '@angular/core';
import { ComponentConnectionService } from 'src/app/core/componentConnection/component-connection.service';
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
    if (!this.request)
      this.buildEmptyRequest();

    return this.registerRequest.languageId;
  }

  selectPolish() {
    this.registerRequest.languageId = 1;
  }

  selectEnglish() {
    this.registerRequest.languageId = 2;
  }

  protected incomingIsValid(): boolean {
    return !this.userService.isLogged();
  }

  protected outcomingIsValid(): boolean {
    return this.isNotEmpty(this.registerRequest.languageId);
  }

  protected prepareView() { }

  protected invalidIncomingAction() {
    this.router.navigate(['']);
  }

  protected invalidOutcomingAction() {
    console.log('Language not selected');
  }
}