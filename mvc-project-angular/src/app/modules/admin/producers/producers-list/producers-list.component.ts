import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ProducerService } from 'src/app/core/producer/producer.service';
import { ProducerListItem } from 'src/app/shared/models/producer-list-item';

@Component({
  selector: 'app-producers-list',
  templateUrl: './producers-list.component.html',
  styleUrls: ['./producers-list.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class ProducersListComponent implements OnInit {

  producers: ProducerListItem[] = [];

  constructor(private producerService: ProducerService) { }

  ngOnInit(): void {
    this.fetchProducers();
  }

  fetchProducers() {
    this.producerService.getAdminList().subscribe(result => {
      this.producers = result.producers;
    });
  }
}
