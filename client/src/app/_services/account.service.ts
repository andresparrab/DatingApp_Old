import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators'; 
import { User } from '../_models/user';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
baseUrl = 'https://localhost:5001/api/'
private currentUserSource = new ReplaySubject<User>(1);
currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient) { }

  login(model: any){
    // In the course they dont typecast the http return answer/response before pipe it
    return this.http.post<User>(this.baseUrl + 'account/login', model).pipe(
      map((response: User) =>{
        const user = response;
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          console.log('this is the user in locastorage:', user)
          this.currentUserSource.next(user);
        }
      })
    )
  }

  setCurrentUser(user: User){
    this.currentUserSource.next(user);
  }

  logout(){
    localStorage.removeItem('user');
    this.currentUserSource.next();
  }
}
