import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable, map } from 'rxjs';
import { Passenger } from '../models/passenger.model';

@Injectable({
  providedIn: 'root'
})
export class PassengerService {
  private readonly http = inject(HttpClient);

  getAll(): Observable<Passenger | null> {
    return this.http.get<Passenger>('http://localhost:5000/api/passenger/get-all').pipe(
      map((passengers: Passenger | null) => {
        if (passengers) {
          return passengers;
        }

        return null;
      })
    );
  }
}