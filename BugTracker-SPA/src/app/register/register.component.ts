import { EmployeeType } from './../model/employee-type.enum';
import { Observable } from 'rxjs';
import { Company } from './../model/company';
import { CompanyService } from './../services/company.service';
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
  companies: Company[];

  constructor(
    private authSerivce: AuthService,
    private alertifyService: AlertifyService,
    private companyService: CompanyService) { }

  ngOnInit() {
    this.loadAllCompanies();
  }
  loadAllCompanies() {
    this.companyService.getAllCompanies().subscribe((allCompanies: Company[]) => {
      this.companies = allCompanies;
    },
      error => this.alertifyService.error(error));
  }

  register() {
    if (!this.checkCompany()) {
      this.alertifyService.error('Company doesn\'t exists');
      return;
    }
    this.model.employeeType = EmployeeType.Regular;
    this.authSerivce.register(this.model).subscribe(
      () => this.alertifyService.success('Registration Successful'),
      error => this.alertifyService.error(error)
    );
  }

  checkCompany(): boolean {
    const rightSideOfMail = this.model.email.split('@');
    const removedDot = rightSideOfMail[1].split('.');
    // tslint:disable-next-line: prefer-for-of
    for (let i = 0; i < this.companies.length; i++) {
      if (this.companies[i].name.toLowerCase() === removedDot[0]) {
        this.model.companyid = this.companies[i].id;
        return true;
      }
    }
    return false;
  }

  cancel() {
    console.log('Canceled');
    this.cancelRegister.emit(false);
  }

}
