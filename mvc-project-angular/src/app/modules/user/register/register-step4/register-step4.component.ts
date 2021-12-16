import { Component, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';
import { ComponentConnectionService } from 'src/app/core/componentConnection/component-connection.service';
import { UserService } from 'src/app/core/user/user.service';
import { RegisterBase } from '../register-base';

@Component({
  selector: 'app-register-step4',
  templateUrl: './register-step4.component.html',
  styleUrls: ['./register-step4.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class RegisterStep4Component extends RegisterBase {

  newsletterOn: boolean;

  agreements: boolean[];

  constructor(protected componentConnection: ComponentConnectionService,
    protected router: Router,
    private userService:UserService) {
    super(componentConnection, router);
  }

  ngOnDestroy(): void {
    this.registerRequest.newsletterOn = this.newsletterOn;
    super.ngOnDestroy();
  }

  changeNewsletterOn() {
    this.newsletterOn = !this.newsletterOn;
  }

  changeAgreement(index) {
    this.agreements[index] = !this.agreements[index];
  }

  submit() {
    if (!this.outcomingIsValid()) {
      this.invalidOutcomingAction();
    }

    // this.userService.register(this.registerRequest).subscribe()
  }

  protected incomingIsValid(): boolean {
    return this.isNotEmpty(this.request)
      && this.isNotEmpty(this.registerRequest)
      && this.isNotEmpty(this.registerRequest.email)
      && this.isNotEmpty(this.address)
      && this.isNotEmpty(this.address.street);
  }

  protected outcomingIsValid(): boolean {
    return this.incomingIsValid();
  }

  protected prepareView() {
    this.agreements = [false, false, false];
    this.newsletterOn = this.registerRequest.newsletterOn;
  }

  protected invalidIncomingAction() {
    this.resetRegister();
  }

  protected invalidOutcomingAction() {
    console.log('step 4 error');
  }
}
