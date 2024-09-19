import { Component, inject, Input, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { User, UserRole } from 'src/api';
import { DefaultUser } from 'src/app/mocks/user.mock';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent implements OnInit {
  @Input() user: User | null = null;
  @Input() readonly: boolean = false;

  private readonly formBuilder = inject(FormBuilder)

  userRoles = Object.values(UserRole)

  formGroup = this.formBuilder.group(DefaultUser)

  ngOnInit() {
    if (this.user) {
      this.formGroup.setValue(this.user);
    }
  }
}
