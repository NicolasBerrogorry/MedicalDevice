import { Component, inject, OnInit } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { User, UserService } from 'src/api';
import { DefaultUlid } from 'src/app/mocks/ulid.mock';
import { DefaultUser } from 'src/app/mocks/user.mock';
import { EntityListPage } from '../entity-list/entity-list.page';

@Component({
  selector: 'app-users',
  templateUrl: './users.page.html',
  styleUrls: ['./users.page.scss']
})
export class UsersPage extends EntityListPage<User> {
  private readonly users = inject(UserService)

  protected override async getAllEntities(): Promise<User[]> {
    const allUsers = await firstValueFrom(this.users.getAllUsers());
    return allUsers;
  }

  protected override getNewEntity(): User {
    const newUser = DefaultUser;
    return newUser;
  }

  protected override getEntityId(entity: User): string | undefined {
    const userId = entity?.id;
    return userId;
  }
}
