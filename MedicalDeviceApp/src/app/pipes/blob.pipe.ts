import { inject, Pipe, PipeTransform } from '@angular/core';
import { Configuration } from 'src/api';

@Pipe({
  name: 'blob'
})
export class BlobPipe implements PipeTransform {
  private readonly configuration = inject(Configuration)

  transform(value?: string | null) {
    if (!value) return null;
    const blobUrl = `${this.configuration.basePath}/blob/${value}`
    return blobUrl;
  }

}
