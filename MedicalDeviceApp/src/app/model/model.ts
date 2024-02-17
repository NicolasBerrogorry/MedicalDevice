import { DeviceSize } from "./device-size";
import { Guid } from "./guid";

export interface Model {
    id: Guid;
    name: string;
    description: string;
    size: DeviceSize;
    photo: Blob;
} 