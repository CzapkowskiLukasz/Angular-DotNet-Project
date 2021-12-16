import { Component, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ComponentConnectionService } from 'src/app/core/componentConnection/component-connection.service';
import { RegisterBase } from '../register-base';

@Component({
  selector: 'app-register-step3',
  templateUrl: './register-step3.component.html',
  styleUrls: ['./register-step3.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class RegisterStep3Component extends RegisterBase {

  form: FormGroup;

  constructor(protected componentConnection: ComponentConnectionService,
    protected router: Router,
    private fb: FormBuilder) {
    super(componentConnection, router);
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      name: ['', Validators.required],
      surname: ['', Validators.required],
      street: ['', Validators.required],
      houseNumber: ['', Validators.required],
      apartmentNumber: [''],
      code: ['', Validators.required],
      city: ['', Validators.required]
    });

    super.ngOnInit();
  }

  ngOnDestroy(): void {
    const formData = this.form.value;
    this.registerRequest.name = formData.name;
    this.registerRequest.surname = formData.surname;

    super.ngOnDestroy();
  }

  protected incomingIsValid(): boolean {
    return this.isNotEmpty(this.registerRequest)
      && this.isNotEmpty(this.registerRequest.languageId)
      && this.isNotEmpty(this.registerRequest.email)
      && this.isNotEmpty(this.registerRequest.password);
  }

  protected outcomingIsValid(): boolean {
    return this.form.valid;
  }

  protected prepareView() {
    this.form.patchValue(this.registerRequest);
  }

  protected invalidIncomingAction() {
    this.resetRegister();
  }

  protected invalidOutcomingAction() {
    console.log(this.form.status);
  }
}
