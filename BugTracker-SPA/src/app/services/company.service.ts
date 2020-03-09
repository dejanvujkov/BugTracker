import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Company } from '../model/company';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {
  baseUrl = environment.apiUrl + 'company/';

  constructor(
    private http: HttpClient
  ) { }

  getAllCompanies(): Observable<Company[]> {
    return this.http.get<Company[]>(this.baseUrl);
  }

}
