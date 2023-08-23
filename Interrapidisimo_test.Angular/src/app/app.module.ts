import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { ReactiveFormsModule } from '@angular/forms';
import { StudentFormComponent } from './student-form/student-form.component';
import { SubjectFormComponent } from './subject-form/subject-form.component';
import { StudentComponent } from './student/student.component';
import { RouterModule, Routes } from '@angular/router';
import { StudentfilteredComponent } from './studentfiltered/studentfiltered.component';
const routes: Routes = [
  { path: 'studentList', component: StudentComponent },
  { path: 'subject', component: SubjectFormComponent },
  { path: 'student', component: StudentFormComponent },
  { path: 'studentbyid/:StudentId', component: StudentfilteredComponent },
  { path: '', redirectTo: '/studentList', pathMatch: 'full' }, // Redirige a /students por defecto
];


@NgModule({
  declarations: [
    AppComponent,
    StudentComponent,
    StudentFormComponent,
    StudentfilteredComponent,
    SubjectFormComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule.forRoot(routes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
