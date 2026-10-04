import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FeedbackService } from '../services/feedback.service';

@Component({
    selector: 'app-feedback',
    templateUrl: './feedback.component.html',
    styleUrls: ['./feedback.component.css']
})
export class FeedbackComponent {
    feedbackForm: FormGroup;
    isSubmitting = false;
    successMessage = '';

    constructor(
        private fb: FormBuilder,
        private feedbackService: FeedbackService
    ) {
        this.feedbackForm = this.fb.group({
            name: ['', Validators.required],
            email: ['', [Validators.required, Validators.email]],
            category: ['suggestion', Validators.required],
            rating: [5, Validators.required],
            message: ['', [Validators.required, Validators.minLength(10), Validators.maxLength(500)]]
        });
    }

    onSubmit() {
        if (this.feedbackForm.valid) {
            this.isSubmitting = true;
            this.successMessage = '';

            this.feedbackService.submitFeedback(this.feedbackForm.value).subscribe({
                next: () => {
                    this.isSubmitting = false;
                    this.successMessage = 'Thank you for your feedback! We appreciate your input.';
                    this.feedbackForm.reset({
                        category: 'suggestion',
                        rating: 5
                    });

                    setTimeout(() => {
                        this.successMessage = '';
                    }, 5000);
                },
                error: (error) => {
                    this.isSubmitting = false;
                    console.error('Submission failed', error);
                    // Handle error (show message to user)
                }
            });
        } else {
            Object.keys(this.feedbackForm.controls).forEach(key => {
                const control = this.feedbackForm.get(key);
                if (control) {
                    control.markAsTouched();
                }
            });
        }
    }
}
