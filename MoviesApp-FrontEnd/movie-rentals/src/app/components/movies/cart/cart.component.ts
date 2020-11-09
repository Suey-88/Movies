import { Component, OnInit } from '@angular/core';
import { CartService } from '../../../services/cart.service';
import { CartItem } from 'src/app/models/cart-item';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent implements OnInit {

  public cartItems: CartItem[];

  constructor(private cartService: CartService) { }

  ngOnInit(): void {
    this.loadCartItems();
    console.log('cart items ' + this.cartItems);
  }

  loadCartItems() {
    this.cartItems = this.cartService.getCartItems();
  }

  getTotal(): number {
    let total = 0;
    this.cartItems.forEach(item => {
      total += (item.qty * item.price)
    })

    return total;
  }
}



