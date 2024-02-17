import { AbstractControl, ValidatorFn } from "@angular/forms";
import { Guid } from "./guid";

export const DefaultBlob = new Blob([], { type: "application/octet-stream" });