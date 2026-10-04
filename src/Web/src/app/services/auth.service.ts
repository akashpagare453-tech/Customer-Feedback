import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, tap } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class AuthService {
    // Use a relative path or environment variable for the API URL
    // For this setup, we assume proxy.conf.json or CORS allows this
    private apiUrl = 'https://localhost:7110/api/auth';
    private tokenKey = 'auth_token';
    private currentUserSubject: BehaviorSubject<any>;
    public currentUser: Observable<any>;

    constructor(private http: HttpClient) {
        this.currentUserSubject = new BehaviorSubject<any>(localStorage.getItem(this.tokenKey));
        this.currentUser = this.currentUserSubject.asObservable();
    }

    public get currentUserValue(): any {
        return this.currentUserSubject.value;
    }

    register(user: any): Observable<any> {
        return this.http.post(`${this.apiUrl}/register`, user);
    }

    login(credentials: any): Observable<any> {
        return this.http.post<any>(`${this.apiUrl}/login`, credentials)
            .pipe(tap(response => {
                if (response && response.token) {
                    localStorage.setItem(this.tokenKey, response.token);
                    this.currentUserSubject.next(response.token);
                }
            }));
    }

    logout() {
        localStorage.removeItem(this.tokenKey);
        this.currentUserSubject.next(null);
    }

    getToken(): string | null {
        return localStorage.getItem(this.tokenKey);
    }
}
