import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ProfesorResponse } from '../student/student.component';
@Injectable({
  providedIn: 'root'
})
export class ProfessorService {
  private apiUrl = 'http://localhost:57678'; 

  constructor(private http: HttpClient) { }

  getProfessors(): Observable<ProfesorResponse> {
    return this.http.get<ProfesorResponse>(`${this.apiUrl}/Professors`);
  }
}
