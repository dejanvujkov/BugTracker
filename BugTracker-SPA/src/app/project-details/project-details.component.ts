import { ActivatedRoute } from '@angular/router';
import { AlertifyService } from './../services/alertify.service';
import { ProjectService } from './../services/project.service';
import { Project } from './../model/project';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-project-details',
  templateUrl: './project-details.component.html',
  styleUrls: ['./project-details.component.css']
})
export class ProjectDetailsComponent implements OnInit {
  project: Project;

  constructor(
    private projectService: ProjectService,
    private alertify: AlertifyService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadProject(this.route.snapshot.params.id);
  }

  loadProject(id: number) {
    this.projectService.getProject(id).subscribe((loadedProject: Project) => {
      this.project = loadedProject;
    }, error => {
      this.alertify.error('Error loading project');
    });
  }

  create() {

  }

  update() {
    this.projectService.update(this.project).subscribe((updatedProject: Project) => {
      this.project = updatedProject;
      this.alertify.success('Project updated successfully');
    }, error => {
      this.alertify.error('Error updating project');
    });
  }

  cancel() {
    this.loadProject(this.route.snapshot.params.id);
  }

}
