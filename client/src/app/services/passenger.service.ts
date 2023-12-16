import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable, map } from 'rxjs';
import { Passenger } from '../models/passenger.model';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class PassengerService {
  readonly #http = inject(HttpClient);

  #apiUrl: string = environment.baseApiUrl + 'passenger/';

  getAll(pageNumber: number): Observable<Passenger[] | null> {
    return this.#http.get<Passenger[]>(`${this.#apiUrl}get-all/${pageNumber}`).pipe(
      map((passengers: Passenger[] | null) => {
        if (passengers) {
          return passengers;
        }

        return null;
      })
    );
  }
}
