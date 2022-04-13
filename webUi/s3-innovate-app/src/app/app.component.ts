import { Component, OnInit } from '@angular/core';
import { Student } from './models/student.model';
import { StudentService } from './services/student.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 's3-innovate-app';
  students: Student[] = [];
  student: Student = {
    id: "",
    name: undefined,
    studentId: undefined,
    cgpa: undefined,
    university: undefined,
    passingYear: undefined
  };

  constructor(private studentService: StudentService) { }
  
  ngOnInit(): void {
    this.get();
  }

  get(){
    this.studentService.getAllStudents().subscribe(respons => {
      this.students = respons
    });
  }

  post(){
    if (this.student.id === ""){
      this.studentService.addStudent(this.student).subscribe(respons =>{
        this.get();
        this.student = {
          id: "",
          name: undefined,
          studentId: undefined,
          cgpa: undefined,
          university: undefined,
          passingYear: undefined
        }
      });
    } else{
      this.put(this.student);
    }    
  }

  delete(id: string){
    this.studentService.deleteStudent(id).subscribe(respons => {
      this.get();
    });
  }

  data(student: Student){
    this.student = student;
  }

  put(student: Student){
    this.studentService.updateStudent(student).subscribe(respons =>{
      this.get();
    });
  }
}
