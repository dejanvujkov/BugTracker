import { Employee } from './../model/employee';
import { AlertifyService } from './../services/alertify.service';
import { EmployeeService } from './../services/employee.service';
import { Component, OnInit } from '@angular/core';
import { TaskService } from '../services/task.service';
import { Task } from '../model/task';

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.css']
})
export class TasksComponent implements OnInit {

  tasks: Task[];
  detailTask: Task;

  constructor(
    private alertify: AlertifyService,
    private taskService: TaskService
  ) { }

  ngOnInit() {
    this.loadAllTaks();
  }

  loadAllTaks() {
    this.taskService.getTasksForUsersCompany().subscribe((tasks: Task[]) => {
      this.tasks = tasks;
    }, error => this.alertify.error(error));
  }

}
