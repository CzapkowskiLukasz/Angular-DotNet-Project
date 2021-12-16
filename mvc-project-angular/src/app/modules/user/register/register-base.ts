import { Component, OnDestroy, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { Subscription } from "rxjs";
import { timeout } from "rxjs/operators";
import { ComponentConnectionService } from "src/app/core/componentConnection/component-connection.service";
import { ValueObject } from "src/app/core/componentConnection/value-object";
import { Address } from "src/app/shared/models/address";
import { RegisterRequest } from "src/app/shared/models/register-request";

@Component({ template: '' })
export abstract class RegisterBase implements OnInit, OnDestroy {

    protected request;

    protected get registerRequest(): RegisterRequest {
        return this.request.userData;
    }

    protected get address(): Address {
        return this.request.address;
    }

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
                    this.request = obj.value;

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
        this.buildEmptyRequest();
        this.router.navigate(['/register']);
    }

    protected buildEmptyRequest() {
        this.request = {
            userData: new RegisterRequest(),
            address: new Address()
        };
    }

    protected sendRequest() {
        const preparedValue: ValueObject = {
            key: this.requestValueKey,
            value: this.request
        }

        this.componentConnection.sendValue(preparedValue);
    }

    protected isNotEmpty(property): boolean {
        return property
            && property != null
            && property != 0
            && property != NaN
            && property != false
            && property != '';
    }
}