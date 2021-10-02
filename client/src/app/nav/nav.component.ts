import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {}
  loggedIn: boolean = false;


  constructor(private accountService: AccountService) { }

  ngOnInit(): void {
    this.getCurrentUser();
  }

  login(){
    this.accountService.login(this.model).subscribe(response => {
      // the response here is the user DTO from the API
      console.log('This is the response: ', response);
      this.loggedIn = true;   
      console.log("Logged in = " +this.loggedIn);
  },error => {
    console.log('this is the F error: ' ,error);
  });
  }

  logout() {
    this.loggedIn = false;
    this.accountService.logout();
    console.log("This is when logged out, logged in = ", this.loggedIn)
  }

  getCurrentUser(){
    this.accountService.currentUser$.subscribe(user => {
      this.loggedIn = !!user;
    })
  }

}
