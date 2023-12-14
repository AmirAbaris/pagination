import { Component } from '@angular/core';
import { BehaviorSubject, switchMap } from 'rxjs';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {
  currentPage$ = new BehaviorSubject<number>(1);

  // currentPageData$ = this.currentPage$.pipe(
  //   switchMap((currentPgae) => )
  // );
}
