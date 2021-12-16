import { Component, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup, RequiredValidator, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ComponentConnectionService } from 'src/app/core/componentConnection/component-connection.service';
import { RegisterBase } from '../register-base';
import { ConfirmedValidator } from './confirmed.validator';

@Component({
  selector: 'app-register-step2',
  templateUrl: './register-step2.component.html',
  styleUrls: ['./register-step2.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class RegisterStep2Component extends RegisterBase {

  form: FormGroup;

  constructor(protected componentConnection: ComponentConnectionService,
    protected router: Router,
    private fb: FormBuilder) {
    super(componentConnection, router);
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      email: ['', Validators.required],
      password: ['', Validators.required],
      repeatPassword: ['', Validators.required]
    }, {
      validator: ConfirmedValidator('password', 'repeatPassword')
    });

    super.ngOnInit();
  }

  ngOnDestroy(): void {
    if (this.form) {
      this.registerRequest.email = this.form.get('email').value;
      this.registerRequest.password = this.form.get('password').value;
    }

    super.ngOnDestroy();
  }

  protected incomingIsValid(): boolean {
    return this.isNotEmpty(this.registerRequest)
      && this.isNotEmpty(this.registerRequest.languageId);
  }

  protected outcomingIsValid(): boolean {
    return this.form.valid;
  }

  protected prepareView(): void {
    // clean password for prevent sending password that user set earlier and may have forgotten
    this.registerRequest.password = '';

    this.form.get('email').setValue(this.registerRequest.email);
  }

  protected invalidIncomingAction() {
    this.resetRegister();
  }

  protected invalidOutcomingAction() {
    console.log(this.form.status);
  }
}
