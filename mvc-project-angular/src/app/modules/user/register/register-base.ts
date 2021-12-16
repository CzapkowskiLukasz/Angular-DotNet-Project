import { Component, OnDestroy, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { Subscription } from "rxjs";
import { timeout } from "rxjs/operators";
import { ComponentConnectionService } from "src/app/core/componentConnection/component-connection.service";
import { ValueObject } from "src/app/core/componentConnection/value-object";
import { RegisterRequest } from "src/app/shared/models/register-request";

@Component({ template: '' })
export abstract class RegisterBase implements OnInit, OnDestroy {

    protected registerRequest: RegisterRequest;

    protected valueSubscribtion: Subscription;

    protected requestValueKey = 'registerRequest';

    constructor(protected componentConnection: ComponentConnectionService,
        protected router: Router) {
    }

    ngOnInit(): void {
        this.valueSubscribtion = this.componentConnection.lastValue
            .pipe(timeout(100))
            .subscribe(obj => {
                if (obj.key == this.requestValueKey) {
                    this.registerRequest = obj.value;

                    if (!this.incomingIsValid())
                        this.invalidIncomingAction();

                    this.prepareView();
                }
            }, err => {
                if (err.name == 'TimeoutError' && !this.incomingIsValid())
                    this.resetRegister();
            });
    }

    ngOnDestroy() {
        if (this.valueSubscribtion)
            this.valueSubscribtion.unsubscribe();

        this.sendRequest();
    }

    next(stepNumber) {
        if (this.outcomingIsValid())
            this.router.navigate(['/register/step' + stepNumber]);
        else
            this.invalidOutcomingAction();
    }

    protected abstract incomingIsValid(): boolean;

    protected abstract outcomingIsValid(): boolean;

    protected abstract prepareView();

    protected abstract invalidIncomingAction();

    protected abstract invalidOutcomingAction();

    protected resetRegister() {
        this.registerRequest = new RegisterRequest();
        this.router.navigate(['/register']);
    }

    protected sendRequest() {
        const preparedValue: ValueObject = {
            key: this.requestValueKey,
            value: this.registerRequest
        }

        this.componentConnection.sendValue(preparedValue);
    }
}