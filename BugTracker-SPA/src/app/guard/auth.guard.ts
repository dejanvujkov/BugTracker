import { AlertifyService } from './../services/alertify.service';
import { AuthService } from './../services/auth.service';
import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(
    private authService: AuthService,
    private router: Router,
    private alertify: AlertifyService
  ) { }
  canActivate(): | boolean {
    if (this.authService.loggedIn()) {
      return true;
    }

    this.alertify.error('You have to login to view content of this page');
    this.router.navigate(['/home']);
    return false;
  }

}
