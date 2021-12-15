import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { Subscription } from 'rxjs';
import { ComponentConnectionService } from 'src/app/core/componentConnection/component-connection.service';
import { RegisterRequest } from 'src/app/shared/models/register-request';

@Component({
  selector: 'app-register-step1',
  templateUrl: './register-step1.component.html',
  styleUrls: ['./register-step1.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class RegisterStep1Component implements OnInit, OnDestroy {

  isEnglish: boolean;
  isPolish: boolean;

  registerRequest: RegisterRequest;

  valueSubscribtion: Subscription;

  constructor(private componentConnection: ComponentConnectionService) {
  }

  ngOnInit(): void {
    this.isEnglish = false;
    this.isPolish = false;

    this.valueSubscribtion = this.componentConnection.lastValue.subscribe(obj => {
      if (obj.key == 'registerRequest') {
        this.registerRequest = obj.value;
      }
    })
  }

  ngOnDestroy() {
    this.valueSubscribtion.unsubscribe();
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

}
