import { httpOptions } from './../shared/httpHeader';
import { AuthService } from './auth.service';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Employee } from '../model/employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  baseUrl = environment.apiUrl + 'employee/';

  constructor(private http: HttpClient, private authService: AuthService) { }

  getLoggedInUser(): Observable<Employee> {
    return this.http.get<Employee>(this.baseUrl + this.authService.decodedToken.nameid);
  }

}
