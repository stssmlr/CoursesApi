using CoursesApi.Core;
using CoursesApi.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Crete connection string
string conStr = builder.Configuration.GetConnectionString("DefaultConnection");

// Add AppDbContext
builder.Services.AddDbContext(conStr);

// Add Repository
builder.Services.AddRepositories();

//Add Mapping


// Add Core Services
builder.Services.AddCoreServices();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
