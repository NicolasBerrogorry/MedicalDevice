import { OnInit, OnDestroy, Input, Output, EventEmitter, inject, Component, OnChanges, SimpleChanges, ChangeDetectorRef } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { UntilDestroy, untilDestroyed } from '@ngneat/until-destroy';
import { firstValueFrom } from 'rxjs';
import { map } from 'rxjs/operators';
import { DefaultUlid } from 'src/app/mocks/ulid.mock';

@UntilDestroy()
@Component({
    template: ''
})
export abstract class EntityComponent<TEntity extends {}> implements OnInit, OnChanges {
    protected readonly formBuilder = inject(FormBuilder);
    protected readonly matDialogData = inject(MAT_DIALOG_DATA, { optional: true }) as TEntity;

    protected abstract createEntity(entity: TEntity): Promise<TEntity>;
    protected abstract updateEntity(id: string, entity: TEntity): Promise<TEntity>;
    protected abstract getEntityDefault(): TEntity;
    protected abstract getEntityId(entity?: TEntity): string | undefined;

    @Input() entity!: TEntity;
    @Input() readonly: boolean = true;

    @Output() submit = new EventEmitter<TEntity>();
    @Output() dirty = new EventEmitter<boolean>();

    formGroup = this.formBuilder.group(this.getEntityDefault());

    get creating(): boolean {
        return !(this.entity && (this.getEntityId(this.entity) != null && this.getEntityId(this.entity) !== DefaultUlid));
    }

    createForm(entity: TEntity) {
        return this.formBuilder.group<TEntity>(entity);
    }

    async ngOnInit() {
        if (this.matDialogData) {
            this.formGroup.reset(this.matDialogData);
        }

        this.formGroup.valueChanges
            .pipe(
                untilDestroyed(this),
                map(() => this.formGroup.dirty)
            )
            .subscribe(dirty => this.dirty.emit(dirty));
    }

    ngOnChanges(changes: SimpleChanges): void {
        var entityChanges = changes['entity']
        if (!entityChanges) return;
        this.formGroup.reset(entityChanges.currentValue);
    }

    async onReset(): Promise<void> {
        this.onSubmit(this.entity);
    }

    async onCreate(): Promise<void> {
        if (!this.formGroup.valid) return;
        const entity = this.formGroup.getRawValue() as TEntity;
        const createdEntity = await this.createEntity(entity);
        this.onSubmit(createdEntity);
    }

    async onUpdate(): Promise<void> {
        if (!this.formGroup.valid) return;
        const entity = this.formGroup.getRawValue() as TEntity;
        const updatedEntity = await this.updateEntity(this.getEntityId(entity)!, entity);
        this.onSubmit(updatedEntity);
    }

    private onSubmit(entity: TEntity): void {
        this.formGroup.reset(entity);
        this.submit.emit(entity);
    }
}