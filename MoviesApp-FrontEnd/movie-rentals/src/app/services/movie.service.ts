import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';


import { Movie } from '../models/movie';
import { moviesUrl } from '../../config/api';

@Injectable()
export class MovieService {
  constructor(private http: HttpClient) { }
  public API = environment.apiUrl;
  public moviesUrl = `${this.API}/movies`;

  public movies: Movie[] = [];

  getAll(): Observable<Movie[]> {
    const url = moviesUrl + '/getAllMovies';
    return this.http.get<Movie[]>(url);
  }

  get(id: string) {
    const url = moviesUrl + '/getMovie';
    return this.http.get(`${url}/${id}`);
  }

  upsert(movie: Movie): Observable<any> {
    let result: Observable<Object>;
    const urlInsert = moviesUrl + '/addMovie';
    const urlUpdate = moviesUrl + '/updateMovie';
    if (movie.id) {
      result = this.http.put(`${urlUpdate}/${movie.id}`, movie);
    } else {
      result = this.http.post(urlInsert, movie);
    }
    return result;
  }


  remove(id: number) {
    const url = moviesUrl + '/deleteMovie';
    return this.http.delete(`${moviesUrl}/${id.toString()}`);
  }


}

