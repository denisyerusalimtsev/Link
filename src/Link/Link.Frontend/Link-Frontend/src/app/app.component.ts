import { Component } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Link';
  constructor(private translate: TranslateService) {
    translate.setDefaultLang('english');
  }

  changeLanguage(selectedLanguage: string) {
    this.translate.setDefaultLang(selectedLanguage);
  }
}
