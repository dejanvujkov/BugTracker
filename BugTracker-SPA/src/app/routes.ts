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
            { path: 'my-team', component: MyTeamComponent, },
            { path: 'tasks', component: TasksComponent, },
            { path: 'messages', component: MessagesComponent, },
        ]
    },

    { path: '**', redirectTo: '', pathMatch: 'full' }
];
