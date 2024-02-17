import { Line } from "./line";
import { Guid } from "./guid";

export interface LineStep {
    id: Guid;
    lineId: Guid;
    description: string;
    line: Line;
}