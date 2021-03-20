import { TaskDetailsComponent } from './task-details/task-details.component';
import { ProjectDetailsComponent } from './project-details/project-details.component';
import { ProjectTasksComponent } from './project-tasks/project-tasks.component';
import { ProjectsComponent } from './projects/projects.component';
import { AuthGuard } from './guard/auth.guard';
import { MessagesComponent } from './messages/messages.component';
import { TasksComponent } from './tasks/tasks.component';
import { MyTeamComponent } from './my-team/my-team.component';
import { HomeComponent } from './home/home.component';
import { Routes } from '@angular/router';

export const appRoutes: Routes = [
    { path: '', component: HomeComponent },
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'teams', component: MyTeamComponent, },
            { path: 'tasks', component: TasksComponent, },
            { path: 'tasks/:id', component: TaskDetailsComponent, },
            { path: 'messages', component: MessagesComponent, },
            { path: 'projects', component: ProjectsComponent, },
            { path: 'projects/:id/tasks', component: ProjectTasksComponent, },
            { path: 'projects/:id', component: ProjectDetailsComponent, },

        ]
    },

    { path: '**', redirectTo: '', pathMatch: 'full' }
];
