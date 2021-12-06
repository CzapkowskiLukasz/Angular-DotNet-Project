import { Component, EventEmitter, OnInit, Output, ViewEncapsulation } from '@angular/core';
import { CountryService } from 'src/app/core/country/country.service';
import { CountryListItem } from 'src/app/shared/models/country-list-item';

@Component({
  selector: 'app-country-list',
  templateUrl: './country-list.component.html',
  styleUrls: ['./country-list.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class CountryListComponent implements OnInit {

  @Output() createCountryEvent = new EventEmitter();

  countries: CountryListItem[] = [];

  constructor(private countryService: CountryService) { }

  ngOnInit(): void {
    this.fetchCountries();
  }

  addCountry() {
    this.createCountryEvent.emit()
  }

  fetchCountries() {
    this.countryService.getAdminList().subscribe(result =>
      this.countries = result.countries);
  }
}
