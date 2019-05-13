import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Teacher } from '../_models/Teacher';

@Injectable({
  providedIn: 'root'
})
export class TeacherService {
  baseURL = 'http://localhost:5000/api/teacher';

     constructor(private http: HttpClient) { }

  getAllTeachers(): Observable<Teacher[]> {
    return this.http.get<Teacher[]>(this.baseURL);
  }

  getTeacherByName(tema: string): Observable<Teacher[]> {
    return this.http.get<Teacher[]>(`${this.baseURL}/getByName/${name}`);
  }

  getTeacherById(id: number): Observable<Teacher> {
    return this.http.get<Teacher>(`${this.baseURL}/${id}`);
  }

  postUpload(file: File, name: string) {
    const fileToUplaod = <File>file[0];
    const formData = new FormData();
    formData.append('file', fileToUplaod, name);

    return this.http.post(`${this.baseURL}/upload`, formData);
  }

  postTeacher(teacher: Teacher) {
    return this.http.post(this.baseURL, teacher);
  }

  putTeacher(teacher: Teacher) {
    return this.http.put(`${this.baseURL}/${teacher.id}`, teacher);
  }

  deleteTeacher(id: number) {
    return this.http.delete(`${this.baseURL}/${id}`);
  }

}
