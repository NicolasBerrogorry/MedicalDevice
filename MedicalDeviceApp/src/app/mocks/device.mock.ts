import { Device } from "src/api";
import { DefaultUlid } from "./ulid.mock";

export const DefaultDevice: Device = {
    id: DefaultUlid,
    photoId: '',
    model: 'New Device',
    serialNumber: '',
    creationDate: "2024-09-20T14:30:00",
    creationUserId: DefaultUlid,
    creationUser: undefined,
}