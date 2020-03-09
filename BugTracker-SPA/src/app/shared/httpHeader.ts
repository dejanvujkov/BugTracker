import { HttpHeaders } from '@angular/common/http';

export const httpOptions = {
    headers: new HttpHeaders({
        Authorization: 'Bearer ' + localStorage.getItem('token')
    })
};
