import { Component, EventEmitter, Input, OnInit, Output, ViewEncapsulation } from '@angular/core';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-expand-form',
  templateUrl: './expand-form.component.html',
  styleUrls: ['./expand-form.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class ExpandFormComponent implements OnInit {

  @Input() descriptionFormControl: FormControl;

  @Input() fileFormControl: FormControl;

  @Output() fileSelected: EventEmitter<any> = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }

  onFileSelected(event) {
    return this.fileSelected.emit(event);
  }
}
