import { Component, EventEmitter, OnInit, Output, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ContinentService } from 'src/app/core/continent/continent.service';
import { CountryService } from 'src/app/core/country/country.service';
import { FilteredDropdownListItem } from 'src/app/shared/models/filtered-dropdown-list-item';

@Component({
  selector: 'app-country-create',
  templateUrl: './country-create.component.html',
  styleUrls: ['./country-create.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class CountryCreateComponent implements OnInit {

  form: FormGroup;

  continentId;

  continentList: FilteredDropdownListItem[] = [];

  isContinentsLoaded: boolean = false;

  constructor(private fb: FormBuilder,
    private continentService: ContinentService,
    private countryService: CountryService) {

    this.form = fb.group({
      name: [''],
      continent: ['']
    });
  }

  ngOnInit(): void {
    this.fetchContinents();
  }

  submit() {
    let newCountry = {
      name: this.form.get('name'),
      continentId: this.continentId
    };

    this.countryService.add(newCountry);
  }

  cancel() {
    this.componentConnection.sendCommand('closeForm');
  }

  finish() {
    this.componentConnection.sendCommand('fetch');
    this.cancel();
  }

  selectContinent(id) {
    this.continentId = id;
  }

  private fetchContinents() {
    this.continentService.getList().subscribe(result =>
      this.continentList = result.continents.map(c => ({
        text: c.name,
        value: c.continentId
      })),
      err => console.log(err),
      () => this.isContinentsLoaded = true);
  }
}
