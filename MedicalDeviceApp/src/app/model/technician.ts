import { Guid } from "./guid";

export interface Technician {
    id: Guid;
    name: string;
    photo: Blob;
    description: string;
}