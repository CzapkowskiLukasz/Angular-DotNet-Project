import { Component, ElementRef, OnInit, Renderer2, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { fromEvent } from 'rxjs';
import { Category } from 'src/app/shared/models/category';

@Component({
  selector: 'app-admin-product-create',
  templateUrl: './admin-product-create.component.html',
  styleUrls: ['./admin-product-create.component.css']
})
export class AdminProductCreateComponent implements OnInit {

  form: FormGroup;

  searchCategoryControl: FormControl;
  searchCategoryFilterText = '';

  searchCategoryList: Category[] = [];
  searchCategoryFilteredList: Category[] = [];

  categoriesNotFetched = false;

  selectedCategoryId?: number;

  dropdownShown = false;

  @ViewChild('catInput', { static: true }) catInputEl: ElementRef;

  @ViewChild('dropdownList', { static: true }) ddl: ElementRef;

  catInputSub;

  private unlistenFocus: () => void;
  private unlistenBlur: () => void;
  private unlistenMouseOver: () => void;



  constructor(
    private fb: FormBuilder,
    private renderer2: Renderer2) {
    this.form = this.fb.group({
      name: [''],
      price: [''],
      warehouseQuantity: [''],
      expertId: [''],
      description: [''],
      categoryId: [''],
      producerId: ['']
    });

    this.searchCategoryControl = new FormControl('');
  }

  ngOnInit(): void {
    this.getSearchList();

  }

  ngAfterViewInit() {
    this.catInputSub = fromEvent(this.catInputEl.nativeElement, 'click')
      .subscribe(r => this.dropdownToggle());

    this.unlistenFocus = this.renderer2.listen(this.catInputEl.nativeElement, 'focus', () => {
      // this.dropdownShown = true;
      let el = this.ddl.nativeElement;
      this.showDdl();
      
      this.unlistenMouseOver = this.renderer2.listen(el, 'mousedown', () => {
        this.unlistenMouseOver();
        this.unlistenBlur();
      });
      this.unlistenBlur = this.renderer2.listen(this.catInputEl.nativeElement, 'blur', () => {
        this.dropdownShown = false;
        this.unlistenBlur();
        this.hideDdl();
      });
    });
  }

  ngOnDestroy() {
    // this.catInputSub.unsubscribe();
    this.unlistenFocus();
  }

  submit(): void {

  }

  private getSearchList() {
    this.searchCategoryList = [
      {
        categoryId: 1,
        name: 'cat1'
      }, {
        categoryId: 2,
        name: 'cat2'
      }
    ];

    this.searchCategoryFilteredList = this.searchCategoryList;
  }

  searchCategoryFilterTextChange() {
    const filterText = this.searchCategoryControl.value;

    if (this.searchCategoryFilterText!.length > filterText.length) {
      this.searchCategoryFilteredList = this.searchCategoryList;
    }

    this.searchCategoryFilterText = filterText;

    this.searchCategoryFilteredList = this.searchCategoryFilteredList.filter(category => {
      return this.categoryFilter(category, filterText);
    })
  }

  dropdownSelectCategory(category: Category) {
    this.searchCategoryControl.setValue(category.name);

    this.selectedCategoryId = category.categoryId;

    this.searchCategoryFilterTextChange()

    // this.dropdownShown = false;
    this.hideDdl();
  }

  dropdownToggle() {
    this.dropdownShown = !this.dropdownShown;
  }

  private categoryFilter(category: Category, filterText: string): boolean {
    const filterTextString = filterText + '';

    const filterTerms = filterTextString.split(' ');
    for (const filterTerm of filterTerms) {
      if (!category.name.includes(filterTerm)) {
        return false;
      }
    }

    return true;
  }

  private showDdl() {
    let el = this.ddl.nativeElement;
    this.renderer2.removeClass(el, 'hide');
    this.renderer2.addClass(el, 'show');
  }

  private hideDdl() {
    let el = this.ddl.nativeElement;
    this.renderer2.removeClass(el, 'show');
    this.renderer2.addClass(el, 'hide');
  }
}
