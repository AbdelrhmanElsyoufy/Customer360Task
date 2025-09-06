import { UsageItem } from "./UsageItem";

export interface UsageResponse {
    status: string;
    message: string;
    data: UsageItem[];
    isSuspended: boolean;
}
