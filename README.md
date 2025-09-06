# Customer 360 Application

A modern telecommunications customer portal that displays usage data for Mobile, Broadband (FBB), and Voice services with an elegant dark-themed UI.

## 🏗️ Architecture

- **Backend**: .NET Core Web API
- **Frontend**: Angular 16 with Bootstrap 5
- **Data**: XML-based mock data repository
- **UI**: Dark theme with purple accents, responsive design

## 📁 Project Structure

```
Customer360/
├── Customer360.Api/                 # .NET Core Web API
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

## 🚀 Getting Started

### Prerequisites

- .NET 6.0 or later
- Node.js 18+ and npm
- Visual Studio or VS Code

### Backend Setup

1. **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/Customer360.git
   cd Customer360
   ```

2. **Restore .NET packages**
   ```bash
   dotnet restore
   ```

3. **Run the API**
   ```bash
   cd Customer360.Api
   dotnet run
   ```
   
   The API will start at `https://localhost:7000` and `http://localhost:5000`

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
   npm start
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

#### Testing Steps

1. **Basic Functionality Test**
   ```
   1. Open the application
   2. Enter "Mobile123" in the search box
   3. Click search or press Enter
   4. Verify usage data displays with progress circles
   5. Click "Details" button to view detailed breakdown
   ```

2. **Service Type Cycling**
   ```
   1. Click the service type icon (phone/wifi/telephone)
   2. Verify icon changes between Mobile/Broadband/Voice
   3. Perform search with different service types
   ```

3. **Carousel Navigation**
   ```
   1. Search for "Mobile123" (has multiple usage items)
   2. Use dots at bottom to navigate between cards
   3. Verify smooth transitions
   ```

4. **Suspension Handling**
   ```
   1. Enter "Suspended123"
   2. Verify suspension warning appears
   3. Check that no usage data is shown
   ```

5. **Error Handling**
   ```
   1. Enter invalid service number
   2. Verify appropriate error message
   3. Test with empty input
   ```

### API Testing

#### Using Swagger UI
1. Navigate to `https://localhost:7000/swagger`
2. Test the `/api/UsageSummary` endpoint with different parameters

#### Using curl
```bash
# Test successful response
curl "https://localhost:7000/api/UsageSummary?serviceType=Mobile&serviceNumber=Mobile123"

# Test suspended service
curl "https://localhost:7000/api/UsageSummary?serviceType=Mobile&serviceNumber=Suspended123"

# Test error case
curl "https://localhost:7000/api/UsageSummary?serviceType=Invalid&serviceNumber=Test123"
```

#### Expected API Responses

**Successful Response:**
```json
{
  "status": "Success",
  "message": "Usage data retrieved successfully.",
  "data": [
    {
      "freeUnitName": "Corporate Mobile Internet",
      "unitsInitialNumber": 21800,
      "unitsUnUsedAmount": 231,
      "unitsUsedAmount": 21569,
      "unit": "MB",
      "percentage": 98.94,
      "usageStartDate": "8-20-25",
      "usageEndDate": "9-18-25",
      "details": [...]
    }
  ],
  "isSuspended": false
}
```

**Suspended Response:**
```json
{
  "status": "Suspended",
  "message": "The Package has been suspended due to non-payment",
  "data": [],
  "isSuspended": true
}
```

**Error Response:**
```json
{
  "status": "Error",
  "message": "Usage data is not available for Invalid service type.",
  "data": [],
  "isSuspended": false
}
```

## 🔧 Configuration

### CORS Configuration
The API is configured to accept requests from `http://localhost:4200`. To modify this:

```csharp
// In Program.cs
builder.Services.AddCors(options =>
{
    options.AddPolicy("Customer360.UI",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200") // Change this URL
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});
```

### API Base URL
To change the API endpoint in the frontend:

```typescript
// In src/app/services/usage.service.ts
private baseUrl = 'https://localhost:7000/api'; // Change this URL
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

## 🚀 Deployment

### Backend Deployment
```bash
# Publish the API
dotnet publish -c Release -o ./publish

# The published files will be in the ./publish folder
```

### Frontend Deployment
```bash
# Build for production
npm run build

# The built files will be in the ./dist folder
```

## 🐛 Troubleshooting

### Common Issues

1. **CORS Error**
   - Ensure the API is running on the expected port
   - Check CORS configuration in Program.cs

2. **API Connection Issues**
   - Verify the API base URL in the Angular service
   - Check that the API is running and accessible

3. **Build Errors**
   - Run `npm install` to ensure all dependencies are installed
   - Check Node.js version compatibility
