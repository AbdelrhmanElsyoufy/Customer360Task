import { FreeUnitDetail } from "./FreeUnitDetail";

export interface UsageItem {
    freeUnitName: string;
    unitsInitialNumber: number;
    unitsUnUsedAmount: number;
    unitsUsedAmount: number;
    unit: string;
    usageStartDate: string;
    usageEndDate: string;
    percentage: number;
    details: FreeUnitDetail[];
}


