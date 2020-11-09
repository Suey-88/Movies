import { Injectable } from '@angular/core';
import { Subject, Observable } from 'rxjs'
import { Movie } from '../models/movie';
import { CartUpdateModel } from '../models/cart-update-model';


@Injectable({
  providedIn: 'root'
})
export class MessengerService {
  subject = new Subject<Movie>()
  cartSubject = new Subject<CartUpdateModel>()

  constructor() { }

  addToCart(movie: Movie): void {
    this.subject.next(movie)
  }

  updateQty(movie: Movie) {

  }

  getMsg(): Observable<Movie> {
    return this.subject.asObservable()
  }

  getCartSubject(): Observable<CartUpdateModel> {
    return this.cartSubject.asObservable()
  }
}
