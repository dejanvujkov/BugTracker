import { EmployeeType } from './employeeType.enum';
export class Employee {
    id: number;
    name: string;
    surname: string;
    companyId: number;
    teamId: number;
    employeeType: EmployeeType;
    email: string;
}
