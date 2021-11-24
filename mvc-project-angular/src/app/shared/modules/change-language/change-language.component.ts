import { Component, OnInit } from '@angular/core';
import { LocalTranslateService } from 'src/app/core/internationalization/local-translate.service';

@Component({
  selector: 'app-change-language',
  templateUrl: './change-language.component.html',
  styleUrls: ['./change-language.component.css']
})
export class ChangeLanguageComponent implements OnInit {

  constructor(public translate: LocalTranslateService) { }

  ngOnInit(): void {
  }

}
