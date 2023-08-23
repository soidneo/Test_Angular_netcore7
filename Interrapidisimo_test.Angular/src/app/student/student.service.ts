import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { StudentResponse } from './student.component';

@Injectable({
  providedIn: 'root'
})
export class StudentService {
  private apiUrl = 'http://localhost:57678';

  constructor(private http: HttpClient) { }

  getStudents(): Observable<StudentResponse> {
    return this.http.get<StudentResponse>(`${this.apiUrl}/Students`);
  }
}
