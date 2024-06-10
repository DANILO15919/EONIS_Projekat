import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LoginModelDTO } from '../models/LoginModelDTO';
import { Router } from '@angular/router';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  
  private readonly apiUrl = 'https://localhost:7182/api/Token/login';

  constructor(private http: HttpClient,private router:Router) { }

  login(task: LoginModelDTO) : Observable<any> {
    console.log("ovde dobro prosledjuje"+task.email);
    return this.http.post(this.apiUrl, task);

  }

  logout(): void {
    localStorage.removeItem('token'); // Remove the token from local storage
    this.router.navigateByUrl('/login'); // Redirect to the login page
  }
}
