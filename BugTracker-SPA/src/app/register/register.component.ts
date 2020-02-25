import { AuthService } from './../services/auth.service';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  model: any = {};

  constructor(private authSerivce: AuthService) { }

  ngOnInit() {
  }

  register() {
    this.authSerivce.register(this.model).subscribe(
      () => console.log('Registration Successful'),
      error => console.log(error)
    );
  }

  cancel() {
    console.log('Canceled');
    this.cancelRegister.emit(false);
  }

}
