import { Component, OnInit } from '@angular/core';
import { MovieService } from '../../../services/movie.service';
import { Movie } from 'src/app/models/movie';

@Component({
  selector: 'app-movie-list',
  templateUrl: './movie-list.component.html',
  styleUrls: ['./movie-list.component.scss']
})
export class MovieListComponent implements OnInit {

  movieList: Movie[];
  loadingState: boolean;

  constructor(private movieService: MovieService) { }

  ngOnInit(): void {

    this.loadingState = true;
    this.loadMovieList();
  }

  loadMovieList(): void {
    this.movieService.getAll().subscribe((movies: Movie[]) => {
      this.movieList = movies;
      this.loadingState = false;
    });
  }
}
