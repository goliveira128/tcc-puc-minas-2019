import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { AuthService } from '../../core/authentication/auth.service';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.scss']
})
export class IndexComponent implements OnInit {

  name: string;
  isAuthenticated: boolean;
  isAdmin: boolean;
  subscription: Subscription;
  constructor(private authService: AuthService) {
    let userRole = this.authService.role;

    if (userRole === "administrador") {
      this.isAdmin = true;
    }
  }

  ngOnInit() {
    this.subscription = this.authService.authNavStatus$.subscribe(status => this.isAuthenticated = status);
    this.name = this.authService.name;
  } 

}
