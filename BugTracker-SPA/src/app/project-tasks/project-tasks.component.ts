import { TaskStatus } from './../model/task-status.enum';

import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CdkDragDrop, moveItemInArray, transferArrayItem } from '@angular/cdk/drag-drop';
import { Task } from '../model/task';
import { TaskService } from '../services/task.service';
import { AlertifyService } from '../services/alertify.service';

@Component({
  selector: 'app-project-tasks',
  templateUrl: './project-tasks.component.html',
  styleUrls: ['./project-tasks.component.scss']
})
export class ProjectTasksComponent implements OnInit {

  newTasks: Task[];
  inProgressTasks: Task[];
  completedTasks: Task[];

  constructor(
    private taskService: TaskService,
    private alertify: AlertifyService,
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.loadTasksForProject();
  }

  loadTasksForProject() {
    this.taskService.getTasksForProject(+this.route.snapshot.params.id).subscribe((tasks: Task[]) => {
      this.newTasks = tasks.filter(t => t.status === 1);
      this.inProgressTasks = tasks.filter(t => t.status === 2);
      this.completedTasks = tasks.filter(t => t.status === 3);
    }, error => {
      this.alertify.error(error);
    });
  }

  drop(event: CdkDragDrop<Task[]>, status: TaskStatus) {
    if (event.previousContainer === event.container) {
      moveItemInArray(event.container.data, event.previousIndex, event.currentIndex);
    } else {
      transferArrayItem(event.previousContainer.data,
        event.container.data,
        event.previousIndex,
        event.currentIndex);
      const task = event.container.data[event.currentIndex];
      task.status = status;
      this.updateTask(task);
    }
  }

  private updateTask(task: Task) {
    // tslint:disable-next-line: no-shadowed-variable
    this.taskService.update(task).subscribe((task: Task) => {
      this.alertify.success('Updated Task ' + task.id + '!');
    }, error => {
      this.alertify.error('Error updating Task');
    });
  }
}
