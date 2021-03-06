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

  getTasksForCompany(companyId: number): Observable<Task[]> {
    return this.http.get<Task[]>(this.baseUrl + 'company/' + companyId);
  }

  getTasksForProject(projectId: number): Observable<Task[]> {
    return this.http.get<Task[]>(this.baseUrl + 'projectId/' + projectId);
  }

  update(task: Task): Observable<Task> {
    return this.http.put<Task>(this.baseUrl, task);
  }

}
