import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
    selector: 'app-registration',
    templateUrl: './registration.component.html',
    styleUrls: ['./registration.component.css']
})
export class RegistrationComponent {
    registrationForm: FormGroup;
    loading = false;
    error = '';

    constructor(
        private formBuilder: FormBuilder,
        private router: Router,
        private authService: AuthService
    ) {
        this.registrationForm = this.formBuilder.group({
            name: ['', Validators.required],
            email: ['', [Validators.required, Validators.email]],
            password: ['', [Validators.required, Validators.minLength(6)]],
            confirmPassword: ['', Validators.required]
        }, { validator: this.passwordMatchValidator });
    }

    passwordMatchValidator(g: FormGroup) {
        return g.get('password')?.value === g.get('confirmPassword')?.value
            ? null : { 'mismatch': true };
    }

    onSubmit() {
        if (this.registrationForm.invalid) {
            return;
        }

        this.loading = true;
        this.error = '';

        this.authService.register(this.registrationForm.value).subscribe({
            next: () => {
                this.loading = false;
                this.router.navigate(['/login']);
            },
            error: (error) => {
                this.loading = false;
                this.error = error.error?.message || 'Registration failed';
            }
        });
    }
}
