import { Injectable } from '@angular/core';
import { Movie, MovieDataResponseDTO } from '../../models/Movie';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MoviesService {
  baseUrl = 'https://api.themoviedb.org/3/discover/movie?';
  baseUrlId = 'https://api.themoviedb.org/3/';
  apiKey = 'api_key=dd4d819639705d332d531217b4f7c6b6';
  language = 'en-US';
  region = 'US';
  film: Movie[] = [];

  constructor(private http: HttpClient) { }

  getMovieByDateRange(firstDate: string, secondDate: string) {
    return this.http.get<MovieDataResponseDTO>
      (`${this.baseUrl}${this.apiKey}&language=it-it&primary_release_date.gte=${firstDate}&primary_release_date.lte=${secondDate}&sort_by=popularity.desc`);
  }

  getMovieById(id: number) {
    return this.http.get<Movie>
      (`${this.baseUrlId}movie/${id}?${this.apiKey}&language=en-US`);
  }

  getMovie(movieId: number | undefined) {
    return this.http.get<Movie>(`https://api.themoviedb.org/3/movie/${movieId}?${this.apiKey}&language=it-it`);
  }

  getFavouriteMovie(movieId: number | undefined) {
    return this.http.get<Movie>(`${this.baseUrlId}${movieId}?${this.apiKey}&language=it-it`);
  }

  getNowPlaying(page: number): Observable<any> {
    // tslint:disable-next-line: max-line-length
    return this.http.get(`${this.baseUrl}movie/now_playing?api_key=${this.apiKey}&page=${page}&language=${this.language}&region=${this.region}`);
  }

  getPopular(page: number): Observable<any> {
    // tslint:disable-next-line: max-line-length
    return this.http.get(`${this.baseUrl}movie/popular?api_key=${this.apiKey}&page=${page}&language=${this.language}&region=${this.region}`);
  }

  getTopRatedMovies(page: number): Observable<any> {
    // tslint:disable-next-line: max-line-length
    return this.http.get(`${this.baseUrl}movie/top_rated?api_key=${this.apiKey}&page=${page}&language=${this.language}&region=${this.region}`);
  }

  getDiscoverMovies(): Observable<any> {
    return this.http.get(`${this.baseUrl}discover/movie?api_key=${this.apiKey}`);
  }

  getMovieReviews(id: string): Observable<any> {
    return this.http.get(`${this.baseUrl}movie/${id}/reviews?api_key=${this.apiKey}`);
  }

  getMovieCredits(id: string): Observable<any> {
    return this.http.get(`${this.baseUrl}movie/${id}/credits?api_key=${this.apiKey}`);
  }

  getBackdropsImages(id: string) {
    return this.http.get(`${this.baseUrl}movie/${id}/images?api_key=${this.apiKey}`);
  }

  getMovieVideos(id: string): Observable<any> {
    return this.http.get(`${this.baseUrl}movie/${id}/videos?api_key=${this.apiKey}`);
  }
}
