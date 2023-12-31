using MultiTracksAPI.Data;
using MultiTracksAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Added string connection to database
builder.Services.AddSqlServer<MultiTracksDbContext>(builder.Configuration.GetConnectionString("Connection"));

// Added service scopes. Dependency injection.
builder.Services.AddScoped<SongService>();
builder.Services.AddScoped<ArtistService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
    builder
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials()
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
