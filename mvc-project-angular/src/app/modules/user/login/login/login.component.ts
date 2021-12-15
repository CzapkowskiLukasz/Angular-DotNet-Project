import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from 'src/app/core/user/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class LoginComponent implements OnInit {

  form: FormGroup;

  constructor(private fb: FormBuilder,
    private userService: UserService,
    private router: Router) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      email: [''],
      password: ['']
    });
  }

  submit() {
    const request = this.form.value;

    this.userService.login(request).subscribe(result => {
      console.log(result.token);
      this.router.navigate(['']);
    });
  }
}
