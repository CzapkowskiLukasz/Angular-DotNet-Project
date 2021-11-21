import { Component } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'mvc-project-angular';

  constructor(translate: TranslateService){
    translate.addLangs(['en', 'pl']);
    translate.setDefaultLang('en');
    translate.use('en');
  }
}
