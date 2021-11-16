import { Component, ElementRef, EventEmitter, Input, OnInit, Output, Renderer2, ViewChild } from '@angular/core';
import { FilteredDropdownListItem } from '../../models/filtered-dropdown-list-item';

@Component({
  selector: 'app-filtered-dropdown',
  templateUrl: './filtered-dropdown.component.html',
  styleUrls: ['./filtered-dropdown.component.css']
})
export class FilteredDropdownComponent implements OnInit {

  @Input() inputElement;

  @Input() list: FilteredDropdownListItem[];

  @ViewChild('dropdownList', { static: true }) ddl: ElementRef;

  @Output() selectIdEvent = new EventEmitter<string>();

  searchFilterText = '';

  filteredList: FilteredDropdownListItem[] = [];

  itemsNotFetched = false;

  private unlistenFocus: () => void;
  private unlistenBlur: () => void;
  private unlistenChange: () => void;
  private unlistenMouseOver: () => void;

  constructor(private renderer2: Renderer2) { }

  ngOnInit(): void {
    if (this.list == undefined) {
      this.itemsNotFetched = true;
    } else {
      this.filteredList = this.list;
    }
  }

  ngAfterViewInit() {
    this.unlistenFocus = this.renderer2.listen(this.inputElement, 'focus', () => {
      let el = this.ddl.nativeElement;
      this.showDropdown();

      this.unlistenChange = this.renderer2.listen(this.inputElement, 'input', event =>
        this.searchFilterTextChange(event.target));

      this.unlistenMouseOver = this.renderer2.listen(el, 'mousedown', () => {
        this.unlistenMouseOver();
        this.unlistenBlur();
        this.unlistenChange();
      });
      
      this.unlistenBlur = this.renderer2.listen(this.inputElement, 'blur', () => {
        this.unlistenBlur();
        this.unlistenChange();
        this.hideDropdown();
      });
    });
  }

  ngOnDestroy() {
    this.unlistenFocus();
  }


  searchFilterTextChange(input: HTMLInputElement) {
    const filterText = input.value.toLowerCase();

    if (this.searchFilterText!.length > filterText.length) {
      this.filteredList = this.list;
    }

    this.searchFilterText = filterText;

    this.filteredList = this.filteredList.filter(item => {
      return this.filter(item, filterText);
    })
  }

  selectItem(item: FilteredDropdownListItem) {
    this.inputElement.value = item.text;
    this.hideDropdown();
    this.selectIdEvent.emit(item.value);
  }

  private filter(item: FilteredDropdownListItem, filterText: string): boolean {
    const filterTextString = filterText + '';
    const filterTerms = filterTextString.split(' ');
    const itemText = item.text.toLocaleLowerCase();
    for (const filterTerm of filterTerms) {
      if (!itemText.includes(filterTerm)) {
        return false;
      }
    }

    return true;
  }

  private showDropdown() {
    let el = this.ddl.nativeElement;
    this.renderer2.removeClass(el, 'hide');
    this.renderer2.addClass(el, 'show');
  }

  private hideDropdown() {
    let el = this.ddl.nativeElement;
    this.renderer2.removeClass(el, 'show');
    this.renderer2.addClass(el, 'hide');
  }
}
