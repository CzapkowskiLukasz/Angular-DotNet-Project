import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { Subscription } from 'rxjs';
import { ComponentConnectionService } from 'src/app/core/componentConnection/component-connection.service';
import { ProducerService } from 'src/app/core/producer/producer.service';
import { ProducerListItem } from 'src/app/shared/models/producer-list-item';

@Component({
  selector: 'app-producers-list',
  templateUrl: './producers-list.component.html',
  styleUrls: ['./producers-list.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class ProducersListComponent implements OnInit, OnDestroy {

  commandSubscribtion: Subscription;

  producers: ProducerListItem[] = [];

  constructor(private producerService: ProducerService,
    private componentConnection: ComponentConnectionService) { }

  ngOnInit(): void {
    this.fetchProducers();
  }

  ngOnDestroy() {
    if (this.commandSubscribtion)
      this.commandSubscribtion.unsubscribe();
  }

  openForm(id) {
    const preparedValue = {
      key: 'producerId',
      value: id
    };

    this.componentConnection.sendValue(preparedValue);
    this.componentConnection.sendCommand('openForm');
    this.setSubscribtion();
  }

  openEditForm(producer){
    const preparedValue = {
      key: 'producerForEdit',
      value: producer
    };

    this.componentConnection.sendValue(preparedValue);
    this.componentConnection.sendCommand('openForm');
    this.setSubscribtion();
  }

  private setSubscribtion() {
    if (!this.commandSubscribtion) {
      this.commandSubscribtion = this.componentConnection.currentCommand.subscribe(command => {
        if (command == 'fetch') {
          this.fetchProducers();
        } else if (command == 'deleteConfirm') {
          this.finishDelete();
        }
      });
    }
  }

  private fetchProducers() {
    this.producerService.getAdminList().subscribe(result => {
      this.producers = result.producers;
    });
  }

  private finishDelete() {

  }
}
