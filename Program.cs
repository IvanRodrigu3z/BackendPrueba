var builder = WebApplication.CreateBuilder(args);
string _myCords = "myCords";
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors(option => {
    option.AddPolicy(name: _myCords, builder =>
    {
        builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost").AllowAnyHeader().AllowAnyMethod();
    });
});

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

app.UseCors(_myCords);
app.UseAuthorization();

app.MapControllers();

app.Run();
