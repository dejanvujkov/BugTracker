import { EmployeeService } from './../services/employee.service';
import { Employee } from './../model/employee';
import { AlertifyService } from './../services/alertify.service';
import { ProjectService } from './../services/project.service';
import { Project } from './../model/project';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.css']
})
export class ProjectsComponent implements OnInit {

  projects: Project[];
  loggedInEmployee: Employee;
  loggedInUser: Employee;

  constructor(
    private projectService: ProjectService,
    private alertify: AlertifyService,
    private employeeService: EmployeeService,
  ) { }

  ngOnInit() {
    this.loadAllProjectsForCompany();
  }

  loadAllProjectsForCompany() {
    this.projectService.getProjectsForUsersCompany().subscribe((projects: Project[]) => {
      this.projects = projects;
    }, error => {
      this.alertify.error('Error getting Projects for company');
    });
  }


}
