using Customer360.Data;
using Customer360.Service.UsageService;
using Customer360.Service.UsageServiceImp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("Customer360.UI",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
        });
});

// Register services and repository
builder.Services.AddScoped<IUsageSummaryService, UsageSummaryService>();
builder.Services.AddScoped<UsageRepository>();

// Add Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

// ✅ Apply CORS policy
app.UseCors("Customer360.UI");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
