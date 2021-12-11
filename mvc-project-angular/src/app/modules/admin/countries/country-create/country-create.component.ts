import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Subscription } from 'rxjs';
import { ComponentConnectionService } from 'src/app/core/componentConnection/component-connection.service';
import { ContinentService } from 'src/app/core/continent/continent.service';
import { CountryService } from 'src/app/core/country/country.service';
import { FilteredDropdownListItem } from 'src/app/shared/models/filtered-dropdown-list-item';

@Component({
  selector: 'app-country-create',
  templateUrl: './country-create.component.html',
  styleUrls: ['./country-create.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class CountryCreateComponent implements OnInit, OnDestroy {

  form: FormGroup;

  continentId;

  continentList: FilteredDropdownListItem[] = [];

  isContinentsLoaded: boolean = false;

  editedCountryId;

  valueSubscribtion: Subscription;

  constructor(private fb: FormBuilder,
    private continentService: ContinentService,
    private countryService: CountryService,
    private componentConnection: ComponentConnectionService) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      name: [''],
      continent: ['']
    });

    this.fetchContinents();

    this.valueSubscribtion = this.componentConnection.lastValue.subscribe(obj => {
      if (obj.key == 'countryId') {
        this.editedCountryId = obj.value
        this.prepareForm();
      }
    });
  }

  ngOnDestroy() {
    this.valueSubscribtion.unsubscribe();
  }

  submit() {
    if (this.isItEditing) {
      const country = {
        countryId: this.editedCountryId,
        name: this.form.get('name').value,
        continentId: this.continentId
      };

      this.countryService.update(country).subscribe(() =>
        this.finish(),
        err => console.log(err));
    }
    else {
      let newCountry = {
        name: this.form.get('name').value,
        continentId: this.continentId
      };

      this.countryService.add(newCountry).subscribe(() =>
        this.finish(),
        err => console.log(err));
    }
  }

  close() {
    this.componentConnection.sendCommand('closeForm');
  }

  selectContinent(id) {
    this.continentId = id;
  }

  get isItEditing(): boolean {
    return this.editedCountryId != -1;
  }

  private finish() {
    this.componentConnection.sendCommand('fetch');
    this.close();
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

  private fetchCountry() {
    this.countryService.getById(this.editedCountryId).subscribe(result => {
      this.form.get('name').setValue(result.name);

      if (result.continentId > 0) {
        let continent = this.continentList.find(x =>
          x.value == result.continentId);

        this.form.get('continent').setValue(continent.text);
        this.continentId = continent.value;
      }
    })
  }

  private prepareForm() {
    this.form.reset('');
    this.continentId = 0;
    if (this.isItEditing) {
      this.fetchCountry();
    }
  }
}
