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

  itemForDeleteId;

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

  delete(producerId) {
    this.itemForDeleteId = producerId;
    const producer = this.producers.find(x => x.producerId == producerId);
    const nameForDelete = 'producer ' + producer.name;
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
      key: 'producerId',
      value: id
    };

    this.componentConnection.sendValue(preparedValue);
    this.componentConnection.sendCommand('openForm');
    this.setSubscribtion();
  }

  openEditForm(producer) {
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
    this.producerService.delete(this.itemForDeleteId).subscribe(result => {
      if (result) {
        console.log('Successful delete');
        this.fetchProducers();
      }
    });
  }
}
