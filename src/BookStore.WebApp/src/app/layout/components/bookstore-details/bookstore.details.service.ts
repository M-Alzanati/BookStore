import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of, pipe } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { BaseService } from 'src/app/base.service';
import { AuthorModel } from '../../models/author-model';
import { BookModel } from '../../models/book-model';
import { CategoryModel } from '../../models/category-model';
import { ReviewModel } from '../../models/review-model';

@Injectable()
export class BookStoreDetailService extends BaseService {

    constructor(private http: HttpClient) {
        super();
    }

    getCategories(apiKey: string): Observable<CategoryModel[]> {
        return this.http.get(`${this.url}/books/categories?TenantKey=${apiKey}`, this.httpOptions)
            .pipe(
                map((response: CategoryModel[]) => {
                    return response;
                }),
                catchError(error => {
                    return of(error);
                })
            );
    }

    getAuthors(apiKey: string): Observable<AuthorModel[]> {
        return this.http.get(`${this.url}/authors?TenantKey=${apiKey}`, this.httpOptions)
            .pipe(
                map((response: AuthorModel[]) => {
                    return response;
                }),
                catchError(error => {
                    return of(error);
                })
            );
    }

    getBooks(apiKey: string): Observable<BookModel[]> {
        let url = `${this.url}/books?TenantKey=${apiKey}`;
        return this.http
            .get(url, this.httpOptions)
            .pipe(
                map(response => {
                    return response;
                }),
                catchError(e => {
                    return of(null);
                })
            );
    }

    getBookDetails(apiKey: string, name: string): Observable<BookModel[]> {
        let url = `${this.url}/books/name/${name}?TenantKey=${apiKey}`;
        return this.http
            .get(url, this.httpOptions)
            .pipe(
                map(response => {
                    return response;
                }),
                catchError(e => {
                    return of(null);
                })
            );
    }

    addBook(apiKey: string, model: BookModel): Observable<BookModel> {
        let url = `${this.url}/books/add?TenantKey=${apiKey}`;
        return this.http
            .post(url, model, this.httpOptions)
            .pipe(
                map(response => {
                    return response;
                }),
                catchError(e => {
                    return of(null);
                })
            );
    }

    addReview(apiKey: string, model: ReviewModel): Observable<ReviewModel> {
        let url = `${this.url}/reviews/add?TenantKey=${apiKey}`;
        return this.http
            .post(url, model, this.httpOptions)
            .pipe(
                map(response => {
                    return response;
                }),
                catchError(e => {
                    return of(null);
                })
            );
    }
}