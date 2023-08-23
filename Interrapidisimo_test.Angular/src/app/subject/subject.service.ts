import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SubjectResponse } from '../student/student.component';
@Injectable({
  providedIn: 'root'
})
export class SubjectService {
  private apiUrl = 'http://localhost:57678';

  constructor(private http: HttpClient) { }

  getSubjects(): Observable<SubjectResponse> {
    var response = this.http.get<SubjectResponse>(`${this.apiUrl}/Subjects`)
    return response;
  }
}
