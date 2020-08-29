import { EmployeeType } from './employee-type.enum';
export class Employee {
    id: number;
    name: string;
    surname: string;
    companyId: number;
    teamId: number;
    employeeType: EmployeeType;
    email: string;
}
