import { Component } from '@angular/core';
import { LocalTranslateService } from './core/internationalization/local-translate.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'mvc-project-angular';

  constructor(localTranslate: LocalTranslateService){
    localTranslate.init();
    localTranslate.setStoredLanguage();
  }
}
