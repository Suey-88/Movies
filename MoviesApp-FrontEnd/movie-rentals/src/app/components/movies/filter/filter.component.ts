import { Component, OnInit, Pipe } from '@angular/core';
import { Movie } from '../../../models/movie';
import { MovieService } from '../../../services/movie.service';

@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.scss']
})

export class FilterComponent implements OnInit {
  title = 'Angular Search Using ng2-search-filter';
  searchText;
  movies: Movie[];

  constructor(private movieService: MovieService) { }

  ngOnInit(): void {
    this.movieService.getAll().subscribe((movies: Movie[]) => {
      this.movies = movies;
    });
  }

}
