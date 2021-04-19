export interface BookModel {
    name: string;

    id?: string;

    authorId: string;

    categoryId: string;

    price: Number;

    avgRating?: Number;
}