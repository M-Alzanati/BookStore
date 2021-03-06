import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
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

export interface AuthorElement {
  name: string;

  book: string;
}

@Component({
  selector: 'app-bookstore-details',
  templateUrl: './bookstore-details.component.html',
  styleUrls: ['./bookstore-details.component.scss']
})
export class BookstoreDetailsComponent implements OnInit {

  bookModel: BookModel = null;
  categories: CategoryModel[];
  authors: AuthorModel[];
  apiKey: string;
  title: string;
  dataSource: MatTableDataSource<AuthorElement>;
  displayedColumns: string[] = ['name', 'bookName'];

  addBookForm: FormGroup = new FormGroup({
    name: new FormControl(''),
    categorgyId: new FormControl(''),
    authorId: new FormControl(''),
    price: new FormControl(0)
  });

  addReviewForm: FormGroup = new FormGroup({
    text: new FormControl(''),
    bookName: new FormControl(''),
    rating: new FormControl(0, [Validators.min(1), Validators.max(5)])
  });

  getBookDetailsForm: FormGroup = new FormGroup({
    bookName: new FormControl('')
  });

  constructor(
    protected route: ActivatedRoute,
    private dialog: MatDialog,
    private bookstoreService: BookStoreDetailService,
    private sharedService: SharedService,
    private spinner: NgxSpinnerService) { }

  ngOnInit(): void {
    this.apiKey = this.route.snapshot.queryParams['apiKey'];

    this.loadCategories();
    this.loadAuthorsWithBooks();

    this.sharedService.addTenants.subscribe(
      (res: TenantModel) => {
        this.title = res.name;
      }
    );
  }

  loadCategories() {
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
  }

  loadAuthorsWithBooks() {
    this.spinner.show();
    this.bookstoreService
      .getAuthorsWithBooks(this.apiKey)
      .subscribe(
        (res) => {
          this.spinner.hide();
          this.authors = res;

          const mappedAuthors: AuthorElement[] = [];
          for (let author of this.authors) {
            for (let book of author.books) {
              mappedAuthors.push({ book: book, name: author.name });
            }
          }

          this.dataSource = new MatTableDataSource(mappedAuthors);
        },
        (err) => {
          this.spinner.hide();
          this.dialog.open(MessageBoxComponent, { data: err });
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
            this.loadAuthorsWithBooks();
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

    if (this.addReviewForm.valid) {
      this.bookstoreService.addReview(this.apiKey, model)
        .subscribe(
          (res: ReviewModel) => {
            debugger;
            if (!res) {
              this.dialog.open(MessageBoxComponent, { data: { title: 'Error', content: 'Internal Server Error' } });
            } else {
              this.dialog.open(MessageBoxComponent, { data: { title: 'Done', content: `Review Added Successfully` } });
            }
          }
        )
    } else {
      this.dialog.open(MessageBoxComponent, { data: { title: 'Error', content: 'Please Enter A Valid Data' } });
    }
  }

  onGetBookDetails() {
    this.bookstoreService
      .getBookDetails(this.apiKey, this.getBookDetailsForm.get('bookName').value)
      .subscribe(
        (res: BookModel) => {
          if (!res) {
            this.dialog.open(MessageBoxComponent, { data: { title: 'Error', content: 'Book is not in the store' } });
          } else {
            res.authorId = this.authors[this.authors.findIndex(r => r.id == res.authorId)].name;
            res.categoryId = this.categories[this.categories.findIndex(r => r.id == res.categoryId)].name;
            this.bookModel = res;
          }
        }
      )
  }
}
