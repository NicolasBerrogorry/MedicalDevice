import { DeviceSize } from "./device-size";
import { Guid } from "./guid";

export interface Line {
    id: Guid;
    deviceSize: DeviceSize;
    photo: Blob;
    description: string;
}