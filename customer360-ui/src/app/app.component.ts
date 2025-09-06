import { Component } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { UsageComponent } from './component/usage/usage.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [UsageComponent],
  templateUrl:'./app.component.html'
})
export class AppComponent {}