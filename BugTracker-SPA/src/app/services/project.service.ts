import { httpOptions } from './../shared/httpHeader';
import { environment } from './../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Project } from '../model/project';

@Injectable({
  providedIn: 'root'
})
export class ProjectService {

  baseUrl = environment.apiUrl + 'project/';

  constructor(private http: HttpClient) { }

  getProjects(): Observable<Project[]> {
    return this.http.get<Project[]>(this.baseUrl);
  }

  getProject(id: number): Observable<Project> {
    return this.http.get<Project>(this.baseUrl + id);
  }

  getProjectsForComapny(companyId: number): Observable<Project[]> {
    return this.http.get<Project[]>(this.baseUrl + 'company/' + companyId);
  }

}
