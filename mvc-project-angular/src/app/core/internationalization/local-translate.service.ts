import { Injectable } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Injectable({
  providedIn: 'root'
})
export class LocalTranslateService {

  constructor(private translate: TranslateService) { }

  init() {
    this.translate.addLangs(['en', 'pl']);
    this.translate.setDefaultLang('en');
  }

  setStoredLanguage() {
    let currentLanguage = localStorage['language'] || 'en';
    this.translate.use(currentLanguage);
  }

  setLanguage(language: string) {
    if (localStorage) {
      localStorage['language'] = language;
    }

    this.translate.use(language);
  }

  getCurrentLanguage(): string {
    return this.translate.currentLang;
  }
}
