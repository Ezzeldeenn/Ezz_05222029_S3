using Managing_Movie_Collection;
using Managing_Movie_Collection.Repo.Category;
using Managing_Movie_Collection.Repo.Cinema;
using Managing_Movie_Collection.Repo.Director;
using Managing_Movie_Collection.Repo.Movie;
using Managing_Movie_Collection.Repo.Natinality;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(x =>
    x.UseSqlServer(builder.Configuration.GetConnectionString("connection")));

builder.Services.AddScoped<IMovieRepo, MovieRepo>();    
builder.Services.AddScoped<IDirector_Repo, Director_Repo>();    
builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();    
builder.Services.AddScoped<INatonalityRepo, NatonalityRepo>();    
builder.Services.AddScoped<ICinemaRepo, CinemaRepo>();    

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
