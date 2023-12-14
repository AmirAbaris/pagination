import { Component, inject } from '@angular/core';
import { BehaviorSubject, switchMap } from 'rxjs';
import { PassengerService } from '../../services/passenger.service';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {
  private readonly passengerService = inject(PassengerService);

  currentPage$ = new BehaviorSubject<number>(1);

  currentPageData$ = this.currentPage$.pipe(
    switchMap((currentPage) => {
      this.passengerService.getAll().
    })
  );
}
