import { environment } from '../environments/environment';

export const baseUrl= environment.production ? 'http://api.movie.com' : 'https://localhost:44395/api'
export const moviesUrl= baseUrl+ '/movies';
export const cartUrl=baseUrl + '/cart';