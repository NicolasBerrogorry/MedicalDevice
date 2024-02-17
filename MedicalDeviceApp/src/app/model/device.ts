import { DeviceStep } from "./device-step";
import { Guid } from "./guid";
import { Model } from "./model";

export interface Device {
    id: Guid;
    modelId: Guid;
    model: Model;
    deviceSteps: DeviceStep[]
}