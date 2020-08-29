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
    private pojectService: ProjectService,
    private alertify: AlertifyService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadProject(this.route.snapshot.params.id);
  }

  loadProject(id: number) {
    this.pojectService.getProject(id).subscribe((loadedProject: Project) => {
      this.project = loadedProject;
    }, error => {
      this.alertify.error('Error loading project');
    });
  }

  update() {
    // TODO: update project on click
  }

  cancel() {
    // TODO: cancel changes and restore previous values
  }

}
