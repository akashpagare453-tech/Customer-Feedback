import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class FeedbackService {
    // Assuming Feedback API runs on port 7200 (common for second service in VS)
    // Adjust port if necessary based on your launchSettings.json
    private apiUrl = 'https://localhost:7200/api/feedback';

    constructor(private http: HttpClient) { }

    submitFeedback(feedbackData: any): Observable<any> {
        return this.http.post(this.apiUrl, feedbackData);
    }
}
