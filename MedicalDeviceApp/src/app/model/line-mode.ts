import { Guid } from "./guid";
import { LineStep } from "./line-step";
import { Model } from "./model";

export interface LineModel {
    id: Guid;
    modelId: Guid;
    model: Model;
    steps: LineStep[];
}