import { Injectable } from '@angular/core';
import { BehaviorSubject, ReplaySubject } from 'rxjs';
import { ValueObject } from './value-object';

@Injectable({
  providedIn: 'root'
})
export class ComponentConnectionService {

  private currentCommandSubject = new BehaviorSubject<string>('default');
  currentCommand = this.currentCommandSubject.asObservable();

  private lastValueSubject = new ReplaySubject<ValueObject>(1);
  lastValue = this.lastValueSubject.asObservable();

  constructor() { }

  sendCommand(command) {
    this.currentCommandSubject.next(command);
  }

  sendValue(value) {
    this.lastValueSubject.next(value);
  }
}
