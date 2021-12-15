import { Component, OnDestroy, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { Subscription } from "rxjs";
import { ComponentConnectionService } from "src/app/core/componentConnection/component-connection.service";
import { ValueObject } from "src/app/core/componentConnection/value-object";
import { RegisterRequest } from "src/app/shared/models/register-request";

@Component({ template: '' })
export class RegisterBase implements OnInit, OnDestroy {

    protected registerRequest: RegisterRequest;

    protected valueSubscribtion: Subscription;

    protected requestValueKey = 'registerRequest';

    constructor(protected componentConnection: ComponentConnectionService,
        protected router: Router) {
    }

    ngOnInit(): void {
        this.valueSubscribtion = this.componentConnection.lastValue.subscribe(obj => {
            if (obj.key == this.requestValueKey)
                this.registerRequest = obj.value;
        });
    }

    ngOnDestroy() {
        this.valueSubscribtion.unsubscribe();
        this.sendRequest();
    }

    next(stepNumber) {
        this.router.navigate(['/register/step' + stepNumber]);
    }

    protected sendRequest() {
        const preparedValue: ValueObject = {
            key: this.requestValueKey,
            value: this.registerRequest
        }

        this.componentConnection.sendValue(preparedValue);
    }
}