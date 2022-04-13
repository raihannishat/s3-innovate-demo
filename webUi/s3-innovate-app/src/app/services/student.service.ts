import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Student } from '../models/student.model';

@Injectable({
  providedIn: 'root'
})
export class StudentService {
  apiUrl: string = "https://localhost:7000/api/Student";
  
  constructor(private http: HttpClient) { }

  getAllStudents(): Observable<Student[]>{
    return this.http.get<Student[]>(this.apiUrl);
  }

  addStudent(student: Student): Observable<Student>{
    student.id = "00000000-0000-0000-0000-000000000000";
    return this.http.post<Student>(this.apiUrl, student);
  }

  deleteStudent(id: string): Observable<Student>{
    return this.http.delete<Student>(this.apiUrl + "/" + id);
  }

  updateStudent(student: Student): Observable<Student>{
    return this.http.put<Student>(this.apiUrl + "/" + student.id, student);
  }
}
