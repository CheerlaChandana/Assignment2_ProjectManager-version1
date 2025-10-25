using Microsoft.EntityFrameworkCore;
using ProjectManagerApi.Data;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
// using ProjectManagerApi.Services;
var builder = WebApplication.CreateBuilder(args);

// --- 1. Define CORS Policy ---
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000") 
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});

// --- 2. Add Database Context ---
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// --- 3. Add JWT Authentication ---
var jwtKey = builder.Configuration["Jwt:Key"];
if (string.IsNullOrEmpty(jwtKey))
{
    throw new InvalidOperationException("JWT Key is not configured in appsettings.json");
}

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
        };
    });

builder.Services.AddAuthorization();
// --- End of JWT Authentication ---

builder.Services.AddControllers();

// --- All services are added. Now build the app. ---
var app = builder.Build();

// --- 4. Configure the HTTP request pipeline (Middleware) ---

// We comment this out for local development to avoid SSL issues
// app.UseHttpsRedirection();

// --- THIS IS THE CRITICAL ORDER ---
// 1. CORS must be first
app.UseCors(MyAllowSpecificOrigins);

// 2. Authentication (Who are you?)
app.UseAuthentication();

// 3. Authorization (What can you do?)
app.UseAuthorization();
// --- END OF CRITICAL ORDER ---

app.MapControllers();

app.Run();