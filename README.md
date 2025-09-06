# Customer 360 Application
A modern telecommunications customer portal that displays usage data for Mobile, Broadband (FBB), and Voice services with an elegant dark-themed UI.

## Architecture
- **Backend**: .NET 8.0 Web API
- **Frontend**: Angular 16 with Bootstrap 5
- **Data**: XML-based mock data repository
- **UI**: Dark theme with purple accents, responsive design

## Project Structure
```
Customer360/
├── Customer360.Api/                 # .NET 8.0 Web API
│   ├── Controllers/
│   │   └── UsageSummaryController.cs
│   ├── Program.cs
│   └── Customer360.Api.csproj
├── Customer360.Data/                # Data layer
│   ├── Entity/
│   ├── Dto/
│   ├── Response/
│   └── UsageSummaryRepository.cs
├── Customer360.Service/             # Business logic layer
│   ├── UsageService/
│   └── UsageServiceImp/
└── customer360-ui/                  # Angular frontend
    ├── src/
    │   ├── app/
    │   │   ├── components/usage/
    │   │   ├── models/
    │   │   └── services/
    │   ├── assets/
    │   └── styles/
    ├── package.json
    └── angular.json
```

## Getting Started

### Prerequisites
- .NET 8.0 
- Node.js 18+ and npm
- Angular 16.0 
- Visual Studio or VS Code
- IIS (for production deployment)

### Backend Setup
1. **Clone the repository**
   ```bash
   git clone https://github.com/AbdelrhmanElsyoufy/Customer360Task.git
   cd Customer360
   ```

2. **Restore .NET packages**
   ```bash
   dotnet restore
   ```

3. **Run the API (Development)**
   ```bash
   cd Customer360.Api
   dotnet run
   ```
   
   The API will start at `https://localhost:44398` 
   API Endpoint: `https://localhost:44398/api/UsageSummary`



### Frontend Setup
1. **Navigate to the UI folder**
   ```bash
   cd customer360-ui
   ```

2. **Install dependencies**
   ```bash
   npm install
   ```

3. **Start the development server**
   ```bash
   ng serve
   ```
   
   The application will open at `http://localhost:4200`

## 🧪 Testing

### Manual Testing

The application includes several test scenarios with predefined service numbers:

#### Test Cases

| Service Number | Service Type | Expected Result | Description |
|---------------|--------------|-----------------|-------------|
| `Mobile123` | Mobile | Success | Shows mobile internet, voice, and unit data |
| `FBB123` | FBB | Success | Shows broadband usage data |
| `Voice123` | Voice | Success | Shows voice minutes data |
| `WeGoldFbb123` | FBB | Success | Shows merged group + individual data |
| `WeGoldMobile123` | Mobile | Success | Shows merged group + individual data |
| `Suspended123` | Any | Suspended | Shows suspension warning |
| `SuspendedMobile123` | Any | Suspended | Shows suspension warning |
| `InvalidService` | Any | Error | Returns error message |


### API Base URL

// In src/app/services/usage.service.ts
private baseUrl = 'https://localhost:44398/api/UsageSummary'; 
```

## 🎨 Features

- **Multi-Service Support**: Mobile, Broadband, and Voice services
- **Dark Theme UI**: Modern purple-accented dark interface
- **Progress Visualization**: Circular progress indicators
- **Responsive Design**: Works on desktop and mobile
- **Service Suspension Handling**: Special UI for suspended accounts
- **Detailed Breakdowns**: Modal with detailed usage buckets
- **Group Account Support**: Merges individual and group usage data
- **Carousel Navigation**: Smooth transitions between multiple usage items



