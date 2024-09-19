import { Component, inject } from '@angular/core';
import { UserService } from 'src/api';

@Component({
  selector: 'app-users',
  templateUrl: './users.page.html',
  styleUrls: ['./users.page.scss']
})
export class UsersPage {
  private readonly user = inject(UserService)

  users = this.user.getAllUsers();
}
