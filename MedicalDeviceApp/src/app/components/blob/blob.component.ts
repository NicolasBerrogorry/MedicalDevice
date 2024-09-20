import { Component, ElementRef, forwardRef, inject, Input, ViewChild } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import { firstValueFrom } from 'rxjs';
import { BlobService } from 'src/api';

@Component({
  selector: 'app-blob',
  templateUrl: './blob.component.html',
  styleUrls: ['./blob.component.scss'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => BlobComponent),
      multi: true
    }
  ]
})
export class BlobComponent implements ControlValueAccessor {
  @ViewChild('fileInput', { static: false }) fileInput: ElementRef | null = null;

  @Input() previewFallback!: string;
  @Input() readonly: boolean = false;

  private readonly blobService = inject(BlobService)

  private onChange: (value: string | null) => void = () => { };
  private onTouched: () => void = () => { };

  blobId: string | null = null;
  isDisabled: boolean = false;

  writeValue(value: string | null): void {
    this.blobId = value || '';
  }

  registerOnChange(fn: (blobId: string | null) => void): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

  setDisabledState(isDisabled: boolean): void {
    this.isDisabled = isDisabled;
  }

  onInput(value: string | null): void {
    this.blobId = value;
    this.onChange(value);
    this.onTouched();
  }

  onSelectFile() {
    this.fileInput?.nativeElement?.click();
  }

  async onUploadFile(event: any) {
    const input = event.target as HTMLInputElement;
    if (input.files && input.files.length > 0) {
      const blob = input.files[0];
      const blobId = await firstValueFrom(this.blobService.createBlob(blob));
      this.onInput(blobId);
    }
  }
}
