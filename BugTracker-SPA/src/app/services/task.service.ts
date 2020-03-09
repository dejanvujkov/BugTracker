import { Task } from './../model/task';
import { HttpClient } from '@angular/common/http';
import { environment } from './../../environments/environment';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TaskService {
  baseUrl = environment.apiUrl + 'task/';

  constructor(
    private http: HttpClient
  ) { }

  // getTasksForCompany(companyId: number): Observable<Task[]> {

  // }

}
