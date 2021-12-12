import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Subscription } from 'rxjs';
import { ComponentConnectionService } from 'src/app/core/componentConnection/component-connection.service';
import { CountryService } from 'src/app/core/country/country.service';
import { ProducerService } from 'src/app/core/producer/producer.service';
import { FilteredDropdownListItem } from 'src/app/shared/models/filtered-dropdown-list-item';

@Component({
  selector: 'app-producers-add',
  templateUrl: './producers-add.component.html',
  styleUrls: ['./producers-add.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class ProducersAddComponent implements OnInit {

  form: FormGroup;

  countryId;

  countryList: FilteredDropdownListItem[] = [];

  isCountriesLoaded: boolean = false;

  editedProducerId;

  valueSubscribtion: Subscription;

  constructor(private fb: FormBuilder,
    private countryService: CountryService,
    private producerService: ProducerService,
    private componentConnection: ComponentConnectionService) {
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      name: [''],
      country: ['']
    });

    this.fetchCountries();

    this.valueSubscribtion = this.componentConnection.lastValue.subscribe(obj => {
      if (obj.key == 'producerId') {
        this.form.reset('');
        this.countryId = 0;
        this.editedProducerId = obj.value
      }
      else if (obj.key = 'producerForEdit') {
        this.form.reset('');
        this.countryId = 0;
        const producer = obj.value;
        this.editedProducerId = producer.producerId;
        this.form.get('name').setValue(producer.name);
        this.form.get('country').setValue(producer.countryName);
        this.countryId = producer.countryId;
      }
    });
  }

  submit() {
    if (this.isItEditing) {
      const producer = {
        producerId: this.editedProducerId,
        name: this.form.get('name').value,
        countryId: this.countryId
      }

      this.producerService.update(producer).subscribe(() =>
        this.finish(),
        err => console.log(err));
    }
    else {
      let newProducer = {
        name: this.form.get('name').value,
        countryId: this.countryId
      };

      this.producerService.add(newProducer).subscribe(() =>
        this.finish(),
        err => console.log(err));
    }
  }

  close() {
    this.componentConnection.sendCommand('closeForm');
  }

  finish() {
    this.componentConnection.sendCommand('fetch');
    this.close();
  }

  selectCountry(id) {
    this.countryId = id;
  }

  get isItEditing(): boolean {
    return this.editedProducerId != -1;
  }

  private fetchCountries() {
    this.countryService.getDropdownList().subscribe(result =>
      this.countryList = result.countries.map(c => ({
        text: c.name,
        value: c.countryId
      })),
      err => console.log(err),
      () => this.isCountriesLoaded = true);
  }

  // private fetchCountry() {
  //   this.producerService.getById(this.editedProducerId).subscribe(result => {
  //     this.form.get('name').setValue(result.name);

  //     if (result.countryId > 0) {
  //       const country = this.countryList.find(x =>
  //         x.value == result.countryId);

  //       this.form.get('country').setValue(country.text);
  //       this.countryId = country.value;
  //     }
  //   });
  // }

  // private prepareForm() {
  //   this.form.reset('');
  //   this.countryId = 0;
  //   if (this.isItEditing) {
  //     this.fetchCountry();
  //   }
  // }
}
