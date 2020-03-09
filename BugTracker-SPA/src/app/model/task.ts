import { Project } from './project';
import { Employee } from './employee';
export class Task {
    id: number;
    projectId: number;
    project: Project;
    startDate: Date;
    dueDate: Date;
    workerId: number;
    worker: Employee;
    giverId: number;
    percentageDone: number;
    description: string;
    title: string;
}
