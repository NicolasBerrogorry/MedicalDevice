import { Component, inject, OnInit } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { User, UserService } from 'src/api';
import { DefaultUlid } from 'src/app/mocks/ulid.mock';
import { DefaultUser } from 'src/app/mocks/user.mock';

type ListEntry<TEntity> = TEntity & { dirty: boolean }

@Component({
    template: '',
})
export abstract class EntityListPage<TEntity extends {}> implements OnInit {

    protected abstract getAllEntities(): Promise<TEntity[]>;
    protected abstract getNewEntity(): TEntity;
    protected abstract getEntityId(entity: TEntity): string | undefined;

    entries: ListEntry<TEntity>[] | null = null

    async ngOnInit() {
        const entities = await this.getAllEntities();
        const entries: ListEntry<TEntity>[] = entities.map(u => ({ ...u, dirty: false }));
        const newEntry = this.getNewEntity();
        const newEntity: ListEntry<TEntity> = { ...newEntry, dirty: false };
        this.entries = [...entries, Object.assign({}, newEntity)]
    }

    onDirty(index: number, dirty: boolean) {
        if (!this.entries) return;
        if (index < 0) return;
        this.entries[index].dirty = dirty;
    }

    onSubmit(index: number, entity: TEntity) {
        if (!this.entries) return;
        if (index < 0) return;
        Object.assign(this.entries[index], entity);

        const lastEntry = this.entries.at(-1);
        if (!lastEntry) return;

        var entityId = this.getEntityId(lastEntry);
        if (entityId != null && entityId !== DefaultUlid) {
            const newEntity = this.getNewEntity();
            const newEntry: ListEntry<TEntity> = { ...newEntity, dirty: false };
            this.entries.push(Object.assign({}, newEntry));
        }
    }
}
