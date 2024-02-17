import { AbstractControl, ValidatorFn } from "@angular/forms";

export type Guid = `${string}-${string}-${string}-${string}-${string}`;

export const DefaultGuid: Guid = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX";

export const guidRegex = /^[0-9a-f]{8}-[0-9a-f]{4}-[1-5][0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}$/i;

export const GuidValidator: ValidatorFn = (control: AbstractControl): { [key: string]: any } | null => {
    const value = control.value as Guid;
    if (value === DefaultGuid) {
        return { 'isDefault': true };
    } else if (value === null) {
        return { 'isNull': true };
    } else if (!guidRegex.test(value)) {
        return { 'isGuid': true };
    }
    return null;
};