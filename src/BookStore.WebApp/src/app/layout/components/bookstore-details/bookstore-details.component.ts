import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { SharedService } from 'src/app/shared/services';
import { AuthorModel } from '../../models/author-model';
import { BookModel } from '../../models/book-model';
import { CategoryModel } from '../../models/category-model';
import { ReviewModel } from '../../models/review-model';
import { TenantModel } from '../../models/tenant-model';
import { MessageBoxComponent } from '../message-dialog/message-dialog-component';
import { BookStoreDetailService } from './bookstore.details.service';

@Component({
  selector: 'app-bookstore-details',
  templateUrl: './bookstore-details.component.html',
  styleUrls: ['./bookstore-details.component.scss']
})
export class BookstoreDetailsComponent implements OnInit {

  categories: CategoryModel[];
  authors: AuthorModel[];
  apiKey: string;
  title: string;

  addBookForm: FormGroup = new FormGroup({
    name: new FormControl(''),
    categorgyId: new FormControl(''),
    authorId: new FormControl(''),
    price: new FormControl(0)
  });

  addReviewForm: FormGroup = new FormGroup({
    text: new FormControl(''),
    bookName: new FormControl(''),
    rating: new FormControl(0)
  });

  constructor(
    protected route: ActivatedRoute,
    private dialog: MatDialog,
    private bookstoreService: BookStoreDetailService,
    private sharedService: SharedService,
    private spinner: NgxSpinnerService) { }

  ngOnInit(): void {
    this.apiKey = this.route.snapshot.queryParams['apiKey'];

    this.spinner.show();
    this.bookstoreService
      .getCategories(this.apiKey)
      .subscribe(
        (res) => {
          this.spinner.hide();
          this.categories = res;
        },
        (err) => {
          this.spinner.hide();
          this.dialog.open(MessageBoxComponent, { data: err });
        }
      );

    this.spinner.show();
    this.bookstoreService
      .getAuthors(this.apiKey)
      .subscribe(
        (res) => {
          this.spinner.hide();
          this.authors = res;
        },
        (err) => {
          this.spinner.hide();
          this.dialog.open(MessageBoxComponent, { data: err });
        }
      );

    this.sharedService.addTenants.subscribe(
      (res: TenantModel) => {
        this.title = res.name;
      }
    );
  }

  onAddBookFormSubmit() {
    const model: BookModel = {
      name: this.addBookForm.get('name').value,
      authorId: this.addBookForm.get('authorId').value,
      price: this.addBookForm.get('price').value,
      categoryId: this.addBookForm.get('categorgyId').value
    };

    this.bookstoreService.addBook(this.apiKey, model)
      .subscribe(
        (res: BookModel) => {
          if (!res) {
            this.dialog.open(MessageBoxComponent, { data: { title: 'Error', content: 'Internal Server Error' } });
          } else {
            this.dialog.open(MessageBoxComponent, { data: { title: 'Done', content: `${res.name} Has Been Added To Store` } });
          }
        }
      )
  }

  onAddReviewFormSubmit() {
    const model: ReviewModel = {
      bookName: this.addReviewForm.get('bookName').value,
      text: this.addReviewForm.get('text').value,
      rating: this.addReviewForm.get('rating').value
    };

    this.bookstoreService.addReview(this.apiKey, model)
      .subscribe(
        (res: ReviewModel) => {
          if (!res) {
            this.dialog.open(MessageBoxComponent, { data: { title: 'Error', content: 'Internal Server Error' } });
          } else {
            this.dialog.open(MessageBoxComponent, { data: { title: 'Done', content: `Review Added Successfully` } });
          }
        }
      )
  }

}
