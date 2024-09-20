import { Component, inject } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { User, UserRole, UserService } from 'src/api';
import { EntityComponent } from '../entity/entity.component';
import { DefaultUser } from 'src/app/mocks/user.mock';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent extends EntityComponent<User> {
  private readonly userService = inject(UserService);

  userRoles = Object.keys(UserRole)

  protected override async createEntity(entity: User) {
    const createdUser = await firstValueFrom(this.userService.createUser(entity));
    return createdUser;
  }

  protected override async updateEntity(id: string, entity: User): Promise<User> {
    const updatedUser = await firstValueFrom(this.userService.updateUser(id, entity));
    return updatedUser;
  }

  protected override getEntityId(entity?: User) {
    return entity?.id;
  }

  protected override getEntityDefault(): User {
    return DefaultUser;
  }
}
