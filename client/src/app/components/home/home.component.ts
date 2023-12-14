import { Component, inject } from '@angular/core';
import { BehaviorSubject, map, switchMap } from 'rxjs';
import { PassengerService } from '../../services/passenger.service';
import { MatToolbarModule } from '@angular/material/toolbar';
import { CommonModule } from '@angular/common';
import {MatButtonModule} from '@angular/material/button';
import {MatListModule} from '@angular/material/list';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [MatToolbarModule, CommonModule, MatButtonModule, MatListModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {
  private readonly passengerService = inject(PassengerService);

  currentPage$ = new BehaviorSubject<number>(1);

  currentPageData$ = this.currentPage$.pipe(
    switchMap((currentPage) => {
      return this.passengerService.getAll(currentPage).pipe(
        map((passenger) => {
          if (passenger) {
            return passenger.name;
          }

          return null;
        })
      );
    })
  );

  nextPage() {
    this.currentPage$.next(this.currentPage$.value + 1);
  }

  prevPage() {
    if (this.currentPage$.value > 1) {
      this.currentPage$.next(this.currentPage$.value - 1);
    }
  }
}
