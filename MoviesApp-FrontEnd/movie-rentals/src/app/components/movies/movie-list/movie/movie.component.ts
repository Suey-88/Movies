import { Component, OnInit, Input } from '@angular/core';
import { Movie } from 'src/app/models/movie';
import { MessengerService } from 'src/app/services/messenger.service'
import { CartService } from '../../../../services/cart.service';

@Component({
  selector: 'app-movie',
  templateUrl: './movie.component.html',
  styleUrls: ['./movie.component.scss']
})
export class MovieComponent implements OnInit {

  @Input() movieItem: Movie

  public movie = [];
  public stockToCheckout: number = 1;

  constructor(
    private msg: MessengerService,
    private cartService: CartService
  ) { }

  ngOnInit(): void {
    this.movie = this.cartService.getCartItems();
    /*this.msg.getCartSubject().subscribe((cartUpdateModel: CartUpdateModel) => {
      if (this.movieItem.id == cartUpdateModel.movieId) {
        this.movieItem.qty -= stockToCheckout;
      }
    })*/
  }

  handleAddToCart() {
    if (this.stockToCheckout > this.movieItem.qty) {
      alert('hayibo');
    } else {
      this.cartService.addMovieToCart(this.movieItem, this.stockToCheckout);
      if (this.movieItem.qty > 0) {
        this.movieItem.qty -= this.stockToCheckout;
        this.stockToCheckout = 1;
        this.msg.addToCart(this.movieItem)
      }
    }
  }
}
