import { Component, EventEmitter, OnInit, Output, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
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

  @Output() createProducerEvent = new EventEmitter();

  @Output() cancelEvent = new EventEmitter();

  form: FormGroup;

  countryId;
  countryList: FilteredDropdownListItem[] = [];

  isCountriesLoaded: boolean = false;

  constructor(private fb: FormBuilder,
    private countryService: CountryService,
    private producerService: ProducerService) {
    this.form = fb.group({
      name: [''],
      country: ['']
    });
  }

  ngOnInit(): void {
    this.fetchCountries();
  }

  submit() {
    let newProducer = {
      name: this.form.get('name').value,
      countryId: this.countryId
    };

    this.producerService.add(newProducer).subscribe(() =>
      this.createProducerEvent.emit(),
      err => console.log(err));
  }

  cancel() {
    this.cancelEvent.emit();
  }

  selectCountry(id) {
    this.countryId = id;
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
}
