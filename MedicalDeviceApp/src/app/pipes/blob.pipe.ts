import { inject, Pipe, PipeTransform } from '@angular/core';
import { Configuration } from 'src/api';
import { DefaultUlid } from '../mocks/ulid.mock';

@Pipe({
  name: 'blob'
})
export class BlobPipe implements PipeTransform {
  private readonly configuration = inject(Configuration)

  transform(blobId?: string | null) {
    if (!blobId) return null;
    if (blobId === DefaultUlid) return null;
    const blobUrl = `${this.configuration.basePath}/blob/${blobId}`
    return blobUrl;
  }

}
