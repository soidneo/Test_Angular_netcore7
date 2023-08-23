import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Student, StudentResponse } from '../student/student.component';
import { StudentfilteredService } from './studentfiltered.service';

@Component({
  selector: 'studentfiltered-root',
  templateUrl: './studentfiltered.component.html',
  styleUrls: ['./studentfiltered.component.css']
})
export class StudentfilteredComponent implements OnInit {
  public students?: Student[];

  errorMessage!: string;// Define una variable para almacenar la respuesta

  constructor(
    private route: ActivatedRoute,
    private studentfilteredService: StudentfilteredService
  ) { }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      const studentId = params.get('StudentId');
      if (studentId) {
        this.studentfilteredService.getStudentfiltereds(studentId)
          .subscribe(response => {
            this.students = response.students; // Asigna la respuesta a la variable
          }, error => {
            console.error('Error fetching filtered student:', error);
          });
      }
    });
  }
}
