export interface DisplayItem {
    name: string;
    remaining: number;
    total: number;
    used: number; // Added for clarity
    effectiveDate: string;
    expiryDate: string;
    unit: string;
    percentage: number;
    isSuspended: boolean; // Updated logic for this
    details: any[]; // To hold details for the modal
}
