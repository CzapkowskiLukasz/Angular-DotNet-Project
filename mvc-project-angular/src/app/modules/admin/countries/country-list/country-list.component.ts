import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { Subscription } from 'rxjs';
import { ComponentConnectionService } from 'src/app/core/componentConnection/component-connection.service';
import { CountryService } from 'src/app/core/country/country.service';
import { CountryListItem } from 'src/app/shared/models/country-list-item';

@Component({
  selector: 'app-country-list',
  templateUrl: './country-list.component.html',
  styleUrls: ['./country-list.component.css'],
  encapsulation: ViewEncapsulation.Emulated
})
export class CountryListComponent implements OnInit, OnDestroy {

  commandSubscribtion: Subscription;

  itemForDeleteId;

  countries: CountryListItem[] = [];

  constructor(private countryService: CountryService,
    private componentConnection: ComponentConnectionService) { }

  ngOnInit(): void {
    this.fetchCountries();
  }

  ngOnDestroy() {
    if (this.commandSubscribtion)
      this.commandSubscribtion.unsubscribe();
  }

  delete(countryId) {
    this.itemForDeleteId = countryId;
    const country = this.countries.find(x => x.countryId == countryId)
    const nameForDelete = 'country ' + country.name;
    const preparedValue = {
      key: 'itemForDeleteName',
      value: nameForDelete
    };

    this.componentConnection.sendValue(preparedValue);
    this.componentConnection.sendCommand('openDelete');
    this.setSubscribtion();
  }

  openForm(id) {
    const preparedValue = {
      key: 'countryId',
      value: id
    };

    this.componentConnection.sendValue(preparedValue);
    this.componentConnection.sendCommand('openForm');
    this.setSubscribtion();
  }

  private setSubscribtion() {
    if (!this.commandSubscribtion) {
      this.commandSubscribtion = this.componentConnection.currentCommand.subscribe(command => {
        if (command == 'fetch') {
          this.fetchCountries();
        } else if (command == 'deleteConfirm') {
          this.finishDelete();
        }
      });
    }
  }

  private fetchCountries() {
    this.countryService.getAdminList().subscribe(result =>
      this.countries = result.countries);
  }

  private finishDelete() {
    this.countryService.delete(this.itemForDeleteId).subscribe(result => {
      if (result) {
        console.log('Successful delete');
        this.fetchCountries();
      }
    });
  }
}
