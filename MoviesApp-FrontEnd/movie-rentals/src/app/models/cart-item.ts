import { Movie } from './movie';

export class CartItem {
    movieId: number;
    movieName: string;
    qty: number;
    price: number;
    imageUrl:string;

    constructor(movie: Movie, qty: number) {
        this.movieId = movie.id;
        this.movieName = movie.name;
        this.price = movie.price;
        this.qty = qty;
        this.imageUrl=movie.imageUrl;
    }
}
