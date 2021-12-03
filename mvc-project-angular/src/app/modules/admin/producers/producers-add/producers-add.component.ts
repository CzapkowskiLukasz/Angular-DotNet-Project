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
  }

  cancel() {
    this.cancelEvent.emit();
  }

  private fetchCountries(){
    this.countryService.get
  }
}
