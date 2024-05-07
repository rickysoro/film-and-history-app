import { Component, OnInit } from '@angular/core';
import { MoviesService } from '../../@core/services/movies.service';
import { EventsService } from '../../@core/services/events.service';

@Component({
  selector: 'app-welcome',
  templateUrl: './welcome.component.html',
  styleUrl: './welcome.component.scss'
})
export class WelcomeComponent implements OnInit{
  nowPlaying: any;
  popularMovies: any;
  loader = true;
  year: any;

  constructor(private moviesService: MoviesService, private eventsService: EventsService) {
    this.moviesService.getPopular(1).subscribe({
      next: (response) => {console.log(response)
        this.popularMovies = response}
    })
  }

  ngOnInit(): void {
  }
}
