import { Component, OnInit, OnDestroy, ViewChild, ChangeDetectorRef, NgZone } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NgbModal, NgbModalModule } from '@ng-bootstrap/ng-bootstrap';
import { catchError, finalize } from 'rxjs/operators';
import { throwError } from 'rxjs';
import { UsageService } from '../../services/usage.service';
import { UsageItem } from "../../models/UsageItem";
import { UsageResponse } from "../../models/UsageResponse";
import { DisplayItem } from '../../models/DisplayItem';
import { ServiceType } from '../../models/ServiceType';




@Component({
  selector: 'app-usage',
  standalone: true,
  imports: [CommonModule, FormsModule, HttpClientModule, NgbModalModule],
  templateUrl: './usage.component.html',
  styleUrls: ['./usage.component.css'],
  providers: [UsageService]
})
export class UsageComponent implements OnInit, OnDestroy {
  @ViewChild('detailsModal') detailsModal: any;
  serviceTypes: ServiceType[] = [
    { id: 'Mobile', name: 'Mobile', iconClass: 'bi bi-phone', color: '#8b5cf6' },
    { id: 'FBB', name: 'Broadband', iconClass: 'bi bi-wifi', color: '#3b82f6' },
    { id: 'Voice', name: 'Voice', iconClass: 'bi bi-telephone', color: '#10b981' }
  ];
  selectedServiceType = this.serviceTypes[0];
  searchQuery = 'Mobile123';
  usageData: UsageResponse | null = null; 
  displayItems: DisplayItem[] = []; 
  
  detailsData: DisplayItem | null = null; 
  mainCarouselIndex = 0;
  detailsCarouselIndex = 0; 

  isLoading = false;
  error: string | null = null;
  private modalRef: any;

  constructor(
    private usageService: UsageService,
    private modalService: NgbModal,
    private cdr: ChangeDetectorRef,
    private ngZone: NgZone
  ) {}

  ngOnInit(): void {
    this.onSearch();
    this.ngZone.runOutsideAngular(() => {
      if (typeof document !== 'undefined') {
        import('bootstrap').then(bootstrap => {
          const tooltipTriggerList = document.querySelectorAll('[data-bs-toggle="tooltip"]');
          tooltipTriggerList.forEach(tooltipTriggerEl => new (bootstrap as any).Tooltip(tooltipTriggerEl));
        });
      }
    });
  }

  ngOnDestroy(): void {
    if (this.modalRef) { this.modalRef.close(); }
  }

  onSearch(): void {
    if (!this.searchQuery.trim()) {
      this.error = 'Please enter a service number';
      this.usageData = null;
      this.displayItems = [];
      this.isLoading = false;
      return;
    }

    this.isLoading = true;
    this.error = null;
    this.usageService.getUsageSummary(this.selectedServiceType.id, this.searchQuery)
      .pipe(
        catchError(err => {
          this.error = this.getErrorMessage(err);
          this.usageData = null;
          this.displayItems = [];
          return throwError(() => err);
        }),
        finalize(() => {
          this.isLoading = false;
          this.cdr.detectChanges();
        })
      )
      .subscribe({
        next: (response: UsageResponse) => {
          this.usageData = response;
          if (response.status === 'Error' || !response.data || response.data.length === 0) {
            this.error = response.message || 'No usage data available for this service.';
            this.displayItems = [];
          } else {
            this.error = null;
            // Updated: Map API data to displayItems
            this.displayItems = response.data.map(item => this.createDisplayItem(item, response.isSuspended));
          }
          this.mainCarouselIndex = 0;
        }
      });
      
      
      
  }

  createDisplayItem(item: UsageItem, isSuspended: boolean): DisplayItem {
    return {
      name: item.freeUnitName || 'Unknown',
      remaining: item.unitsUnUsedAmount,
      total: item.unitsInitialNumber,
      used: item.unitsUsedAmount,
      effectiveDate: item.usageStartDate,
      expiryDate: item.usageEndDate,
      unit: item.unit,
      percentage: item.percentage,
      isSuspended: isSuspended, 
      details: item.details || []
    };
  }

  cycleServiceType(): void {
    const currentIndex = this.serviceTypes.findIndex(s => s.id === this.selectedServiceType.id);
    this.selectedServiceType = this.serviceTypes[(currentIndex + 1) % this.serviceTypes.length];
    if (this.searchQuery.trim()) { this.onSearch(); }
  }


  goToSlide(index: number): void {
    this.mainCarouselIndex = index;
    this.cdr.detectChanges();
  }

  
  goToDetailSlide(index: number): void {
    this.detailsCarouselIndex = index;
  }

  getCardType(item: DisplayItem): string {
    const name = item.name?.toLowerCase() || '';
    const unit = item.unit?.toLowerCase() || '';
    if (unit === 'mb' || unit === 'gb' || name.includes('internet') || name.includes('data') || name.includes('broadband')) {
      return 'internet';
    } else if (unit === 'minutes' || name.includes('minutes') || name.includes('voice') || name.includes('call')) {
      return 'minutes';
    } else if (unit === 'unit' || name.includes('unit')) {
      return 'units';
    }
    return 'default';
  }
  
  getCardIconClass(item: DisplayItem): string {
    if (item.isSuspended) return 'bi-exclamation-triangle-fill text-warning';
    switch (this.getCardType(item)) {
      case 'internet': return 'bi-wifi';
      case 'minutes': return 'bi-telephone';
      case 'units': return 'bi-box';
      default: return 'bi-star';
    }
  }

  formatNumber(num: number): string {
    return num.toLocaleString();
  }

  openDetails(item: DisplayItem): void {
    if (item.isSuspended || !item.details || item.details.length === 0) {
        return;
    }
  
    
    this.detailsData = item;
    this.detailsCarouselIndex = 0; 
    this.modalRef = this.modalService.open(this.detailsModal, { centered: true, size: 'lg' });
  }

  private getErrorMessage(error: any): string {
    if (error.status === 0) return 'Unable to connect to server. Please check your connection.';
    if (error.status === 404) return `No usage data found for ${this.selectedServiceType.name} service: ${this.searchQuery}`;
    if (error.status === 400) return 'Invalid service number format. Please check and try again.';
    return error.message || 'An error occurred while loading data.';
  }

  getUnitForServiceType(serviceType: string): string {
  switch (serviceType) {
    case 'Mobile':
      return 'Unit';
    case 'Voice':
      return 'Min';
    case 'FBB':
      return 'GB';
    default:
      return 'Unit'; 
  }
}
}