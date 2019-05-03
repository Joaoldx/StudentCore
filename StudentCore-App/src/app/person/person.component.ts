import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'src/app/_services/auth.service';
import { Router } from '@angular/router';
import { Person } from '../_models/Person';
import {Student} from '../_models/Student';
import {HttpClient} from '@angular/common/http';

@Component({
    selector: 'app-registration',
    templateUrl: './person.component.html',
    styleUrls: ['./person.component.css']
})
export class PersonComponent implements OnInit {

    baseURL = 'http://localhost:5000/api/student';
    registerForm: FormGroup;
    person: Person;

    constructor(private authService: AuthService
        , public router: Router
        , public fb: FormBuilder
        , private toastr: ToastrService
        , private http: HttpClient) {
    }

    ngOnInit() {
        this.validation();
    }

    validation() {
        this.registerForm = this.fb.group({
            fullName: ['', Validators.required],
            email: ['', [Validators.required, Validators.email]],
            birthday: ['', Validators.required],
        });
    }

    personRegister() {
        if (this.registerForm.valid) {
            this.authService.register(this.person).subscribe(
                () => {
                    this.router.navigate(['/students']);
                    this.toastr.success('Cadastro Realizado');
                }, error => {
                    const erro = error.error;
                    erro.forEach(element => {
                        switch (element.code) {
                            case 'DuplicateUserName':
                                this.toastr.error('Cadastro Duplicado!');
                                break;
                            default:
                                this.toastr.error(`Erro no Cadatro! CODE: ${element.code}`);
                                break;
                        }
                    });
                }

            );
        }
    }

    postStudent(student: Student) {
        return this.http.post(this.baseURL, student);
    }
}
