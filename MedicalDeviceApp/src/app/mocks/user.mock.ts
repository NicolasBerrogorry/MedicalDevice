import { User } from "src/api";
import { DefaultULID } from "./ulid.mock";

export const DefaultUser: User = {
    id: DefaultULID,
    initials: 'Type user initials',
    name: 'Type user name',
    description: 'Type user description',
    photoId: DefaultULID,
    role: 'Cashier',
}