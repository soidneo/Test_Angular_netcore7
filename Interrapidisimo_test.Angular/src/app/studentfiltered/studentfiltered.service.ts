import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { StudentResponse } from '../student/student.component';

@Injectable({
  providedIn: 'root'
})
export class StudentfilteredService {
  private apiUrl = 'http://localhost:57678';

  constructor(private http: HttpClient) { }

  getStudentfiltereds(studentId: string): Observable<StudentResponse> {
    return this.http.get<StudentResponse>(`${this.apiUrl}/FilteredStudents/${studentId}`);
  }
}
