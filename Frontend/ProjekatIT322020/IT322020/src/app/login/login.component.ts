//import { ToastrService } from 'ngx-toastr';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { Token } from '@angular/compiler';
import { jwtDecode } from 'jwt-decode';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styles: []
})
export class LoginComponent implements OnInit {
  formModel = {
    email: '',
    lozinka: ''
  }
  constructor(private service: AuthService, private router: Router) { }

  ngOnInit() {
  }

  onSubmit(form: NgForm) {
    this.service.login(this.formModel).subscribe(
      (res: any) => {
        localStorage.setItem('token', res.token);
        const decodedToken: { email: string, role: string } = jwtDecode(res.token);
        const userRole = decodedToken.role;
        console.log("ajmooo micooo"+userRole);
        this.router.navigateByUrl('/home');
      }
    );
  }
}