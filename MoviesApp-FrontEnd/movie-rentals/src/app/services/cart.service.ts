import { Injectable } from '@angular/core';
import { CartItem } from '../models/cart-item';
import { Movie } from '../models/movie';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  private cartItems: CartItem[] = [];

  constructor() { }

  getCartItems(): CartItem[] {
    return this.cartItems  ;
  }

  addMovieToCart(movie: Movie, qty: number): void {
    this.cartItems.push(new CartItem(movie, qty));
  }
}
