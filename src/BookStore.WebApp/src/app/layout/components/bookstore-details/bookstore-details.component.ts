import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BookStoreDetailService } from './bookstore.details.service';

@Component({
  selector: 'app-bookstore-details',
  templateUrl: './bookstore-details.component.html',
  styleUrls: ['./bookstore-details.component.scss']
})
export class BookstoreDetailsComponent implements OnInit {

  apiKey: string;

  constructor(protected route: ActivatedRoute, private bookstoreService: BookStoreDetailService) { }

  ngOnInit(): void {
    this.apiKey = this.route.snapshot.queryParams['apiKey'];

    this.bookstoreService
      .getCategories(this.apiKey)
      .subscribe(
        (res) => {
          console.log(res);
        },
        (err) => {
          console.log(err);
        }
      );

    this.bookstoreService
      .getAuthors(this.apiKey)
      .subscribe(
        (res) => {
          console.log(res);
        },
        (err) => {
          console.log(err);
        }
      );
  }

}
