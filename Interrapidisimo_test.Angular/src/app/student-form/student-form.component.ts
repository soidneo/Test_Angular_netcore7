import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

interface StudentCreateResponse {
  id: string,
  name: string|null
}

@Component({
  selector: 'student-form',
  templateUrl: './student-form.component.html',
  styleUrls: ['./student-form.component.css']
})
export class StudentFormComponent implements OnInit {
  studentForm!: FormGroup;

  constructor(private formBuilder: FormBuilder, private http: HttpClient) { }

  ngOnInit(): void {
    this.studentForm = this.formBuilder.group({
      name: ['', Validators.nullValidator]
    });
  }

  onSubmit(): void {
    if (this.studentForm.invalid) {
      return;
    }

    const newStudent = {
      name: this.studentForm.value.name
    };

    this.http.post<StudentCreateResponse>('http://localhost:57678/addStudent', newStudent)
      .subscribe(result => {
        console.log('Student created:', result);
      }, error => {
        console.error('Error creating student:', error);
      });
  }
}
