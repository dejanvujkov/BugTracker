import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  users: any;

  constructor(
    private http: HttpClient
  ) { }

  ngOnInit() {
    this.getUsers();
  }

  getUsers() {
    this.http.get('http://localhost:5000/employee').subscribe(response => {
      this.users = response;
    }, error => console.log(error));
  }

}
