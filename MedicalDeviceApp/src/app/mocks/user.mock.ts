import { User } from "src/api";
import { DefaultUlid } from "./ulid.mock";

export const DefaultUser: User = {
    id: DefaultUlid,
    initials: '',
    name: 'New User',
    description: '',
    photoId: DefaultUlid,
    role: 'Cashier',
}