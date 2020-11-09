import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/shared/header/header.component';
import { FooterComponent } from './components/shared/footer/footer.component';
import { NavComponent } from './components/shared/nav/nav.component';
import { MoviesComponent } from './components/movies/movies.component';
import { FilterComponent } from './components/movies/filter/filter.component';
import { MovieListComponent } from './components/movies/movie-list/movie-list.component';
import { CartComponent } from './components/movies/cart/cart.component';
import { CartItemComponent } from './components/movies/cart/cart-item/cart-item.component';
import { MovieComponent } from './components/movies/movie-list/movie/movie.component';
import { FormsModule } from '@angular/forms';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { from } from 'rxjs';
import { MovieService } from './services/movie.service';



@NgModule({

  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    NavComponent,
    MoviesComponent,
    FilterComponent,
    MovieListComponent,
    CartComponent,
    CartItemComponent,
    MovieComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    Ng2SearchPipeModule,
    HttpClientModule
  ],
  providers: [MovieService],
  bootstrap: [AppComponent]
})
export class AppModule { }
