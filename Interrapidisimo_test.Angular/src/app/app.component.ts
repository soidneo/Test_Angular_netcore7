import { Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { StudentFormComponent } from './student-form/student-form.component';
import { SubjectFormComponent } from './subject-form/subject-form.component';
import { StudentComponent } from './student/student.component';

const routes: Routes = [
  { path: 'studentList', component: StudentComponent },
  { path: 'subject', component: SubjectFormComponent },
  { path: 'student', component: StudentFormComponent },
  { path: '', redirectTo: '/studentList', pathMatch: 'full' }, // Redirige a /students por defecto
];

@Component({
  selector: 'app-root',
  template: '<router-outlet></router-outlet>',
})
export class AppComponent {
    title!: string;
}
