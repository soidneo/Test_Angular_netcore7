import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { StudentService } from '../student/student.service';
import { ProfessorService } from '../professor/professor.service';
import { SubjectService } from '../subject/subject.service';
import { ProfesorResponse, StudentResponse, SubjectResponse } from '../student/student.component';
import { catchError, throwError } from 'rxjs';
interface SubjectRegisterResponse {
  student:any
}
@Component({
  selector: 'subject-form',
  templateUrl: './subject-form.component.html',
  styleUrls: ['./subject-form.component.css']
})
export class SubjectFormComponent implements OnInit {
  subjectForm!: FormGroup;
  students?: StudentResponse;
  subjects?: SubjectResponse ;
  professors?: ProfesorResponse;
  errorMessage!: string;

  constructor(private formBuilder: FormBuilder,
    private studentService: StudentService,
    private professorService: ProfessorService,
    private subjectService: SubjectService,
    private http: HttpClient) { }

  ngOnInit(): void {
    this.subjectForm = this.formBuilder.group({
      studentId: ['', Validators.required],
      subjectId: ['', Validators.required],
      professorId: ['', Validators.required]
    });

    // Obtener lista de estudiantes
    this.studentService.getStudents().subscribe(students => {
      this.students = students;
    });

    // Obtener lista de profesores
    this.professorService.getProfessors().subscribe(professors => {
      this.professors = professors;
    });

    // Obtener lista de materias
    this.subjectService.getSubjects().subscribe(
      result => {
        this.subjects = result;
    },
      error => {
        this.errorMessage = 'Error al registrar la materia. Por favor, inténtalo nuevamente.'+error;
    });
  }


  onSubmit(): void {
    if (this.subjectForm.invalid) {
      return;
    }

    const newSubjectRegistration = {
      studentId: this.subjectForm.value.studentId,
      subjectId: this.subjectForm.value.subjectId,
      professorId: this.subjectForm.value.professorId
    };

    this.http.post<SubjectRegisterResponse>('http://localhost:57678/registerSubject', newSubjectRegistration)
      .pipe(
        catchError((errorResponse) => {
          const errorMessage = 'Error al registrar la materia. Por favor, inténtalo nuevamente.';

          if (errorResponse && errorResponse.error && errorResponse.error.errors && errorResponse.error.errors.GeneralErrors) {
            const generalErrors = errorResponse.error.errors.GeneralErrors;
            return throwError(`${errorMessage} ${generalErrors.join(', ')}`);
          } else {
            return throwError(errorMessage);
          }
        })
      )
      .subscribe(result => {
        console.log('Student created:', result);
      }, error => {
        this.errorMessage = error;
      });
  }
}
