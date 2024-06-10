import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ProductServiceService {
  private readonly BaseURI = 'https://localhost:7182/api/Proizvod'; // Update with your actual API endpoint

  constructor(private http: HttpClient) { }

  GetProizvods(): Observable<any[]> {
    return this.http.get<any[]>(this.BaseURI).pipe(
      catchError(error => {
        console.error('Error fetching products:', error);
        return throwError('Error fetching products. Please try again later.');
      })
    );
  }
}
