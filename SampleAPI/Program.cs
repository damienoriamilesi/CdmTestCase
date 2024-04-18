using Microsoft.EntityFrameworkCore;
using SampleAPI.ToRefactor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
// Add framework services.
builder.Services.AddDbContext<PersonDbContext>(options =>
    //options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    options.UseSqlite("Data Source=SampleApi.db")
    );

builder.Services.AddScoped<PersonRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
var filePath = Path.Combine(AppContext.BaseDirectory, "SampleAPI.xml");
builder.Services.AddSwaggerGen(cfg => cfg.IncludeXmlComments(filePath, true));

var app = builder.Build();

// Ensure database is created during application startup
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<PersonDbContext>();
    await dbContext.Database.EnsureCreatedAsync();

    if (!dbContext.Employees.Any())
    {
        dbContext.Employees.AddRange(TestFixture.BuildEmployees());
        dbContext.SaveChanges();
    }
}


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
