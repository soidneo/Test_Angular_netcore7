import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'student-root',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css']
})
export class StudentComponent {
  public students?: Student[];

  constructor(http: HttpClient, private router: Router) {
    http.get<StudentResponse>('http://localhost:57678/Students').subscribe(result => {
      this.students = result.students;
      console.log(result);
      console.log(result.students);
    }, error => console.error(error));
    this.router.navigate(['/studentList']);
    }

  title = 'Estudiantes';
}
export interface StudentResponse {
  students: Student[];
}
export interface ProfesorResponse {
  professors: Professor[];
}
export interface SubjectResponse {
  subjects: Subject[];
}
export interface Student {
  id: string;
  name: string;
  registeredSubjects: RegisteredSubject[];
}

export interface RegisteredSubject {
  studentId: string;
  subjectId: string;
  professorId: string;
  subject: Subject;
  professor: Professor;
  id: string;
}

export interface Subject {
  name: string;
  credits: number;
  id: string;
}

export interface Professor {
  name: string;
  id: string;
}
