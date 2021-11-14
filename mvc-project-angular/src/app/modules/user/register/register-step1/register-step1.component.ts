import { Component, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-register-step1',
  templateUrl: './register-step1.component.html',
  styleUrls: ['./register-step1.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class RegisterStep1Component implements OnInit {

  isEnglish: boolean;
  isPolish: boolean;

  constructor() {
    this.isEnglish = false;
    this.isPolish = false;
   }

  ngOnInit(): void {
  }
  
  selectEnglish(){
  this.isEnglish = true
  this.isPolish = false
  }

  selectPolish(){
    this.isPolish = true
    this.isEnglish = false
  }
}
