import { Component, EventEmitter, OnInit, Output, ViewEncapsulation } from '@angular/core';
import { ProducerService } from 'src/app/core/producer/producer.service';
import { ProducerListItem } from 'src/app/shared/models/producer-list-item';

@Component({
  selector: 'app-producers-list',
  templateUrl: './producers-list.component.html',
  styleUrls: ['./producers-list.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class ProducersListComponent implements OnInit {

  @Output() createProducerEvent = new EventEmitter();

  producers: ProducerListItem[] = [];

  constructor(private producerService: ProducerService) { }

  ngOnInit(): void {
    this.fetchProducers();
  }

  addProducer() {
    this.createProducerEvent.emit()
  }

  fetchProducers() {
    this.producerService.getAdminList().subscribe(result => {
      this.producers = result.producers;
    });
  }
}
