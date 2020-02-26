import { AlertifyService } from './../services/alertify.service';
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

  constructor(
    private authSerivce: AuthService,
    private alertifyService: AlertifyService) { }

  ngOnInit() {
  }

  register() {
    this.authSerivce.register(this.model).subscribe(
      () => this.alertifyService.success('Registration Successful'),
      error => this.alertifyService.error(error)
    );
  }

  cancel() {
    console.log('Canceled');
    this.cancelRegister.emit(false);
  }

}
