import { ActivatedRoute } from '@angular/router';
import { AlertifyService } from './../services/alertify.service';
import { TaskService } from './../services/task.service';
import { Task } from './../model/task';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'task-details',
  templateUrl: './task-details.component.html',
  styleUrls: ['./task-details.component.css']
})
export class TaskDetailsComponent implements OnInit {

  task: Task;
  constructor(private taskService: TaskService, private alertify: AlertifyService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.getTaskDetails(this.route.snapshot.params.id);
  }

  getTaskDetails(id: number) {
    this.taskService.getSingleTask(id).subscribe((task: Task) => {
      this.task = task;
    });
  }

}
