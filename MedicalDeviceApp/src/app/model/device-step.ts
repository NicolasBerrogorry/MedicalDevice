import { Guid } from "./guid";
import { LineStep } from "./line-step";

export interface DeviceStep {
    id: Guid;
    lineStepId: Guid;
    inspection: string;
    task: string;
    lineStep: LineStep;
}