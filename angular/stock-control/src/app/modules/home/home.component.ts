import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { lastValueFrom } from 'rxjs';
import { ToastService } from '../../services/toast/toast.service';
import { UserService } from '../../services/user/user.service';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {

  loginCard = true

  loginForm!: FormGroup;
  registerForm!: FormGroup;
  constructor(
    private formBuilder: FormBuilder,
    private userService: UserService,
    private cookieService: CookieService,
    private toastService: ToastService,
    private router: Router
  ) { }

  ngOnInit() { 
    this.startForms();
  }

  startForms() {
    this.loginForm = this.formBuilder.group({
      email: ['', Validators.required],
      password: ['', Validators.required]
    });

    this.registerForm = this.formBuilder.group({
      name: ['', Validators.required],
      email: ['', Validators.required],
      password: ['', Validators.required],
    });
  }
  onSubmitLogin() {
    if (this.loginForm.valid) {
      lastValueFrom(this.userService.authUser(this.loginForm.value))
        .then((response) => {
          this.cookieService.set('USER_INFO', response?.token)
          this.toastService.showSuccess('Login realizado com sucesso!');
          this.loginForm.reset();
          this.router.navigate(['/dashboard']);
        })
        .catch((error) => {
          this.toastService.showError('Erro ao realizar login. Verifique suas credenciais.');
        });

    }
  }
  onSubmitRegister() {
    if (this.registerForm.valid) {
      console.log(this.registerForm.value);
      lastValueFrom(this.userService.createUser(this.registerForm.value))
        .then((response) => {
          this.toastService.showSuccess('Usuário criado com sucesso!');
          this.registerForm.reset();
          this.toggleLoginCard();
        })
        .catch((error) => {
          this.toastService.showError('Erro ao criar usuário. Verifique os dados informados.');
        });
    }
  }
  toggleLoginCard() {
    this.loginCard = !this.loginCard;
  }
  
}
