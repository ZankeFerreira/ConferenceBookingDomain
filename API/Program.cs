
using ConferenceBookingDomain;
 
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<BookingManager>();

var dataDirectory = Path.Combine(
    builder.Environment.ContentRootPath,
    "Data"
);

builder.Services.AddSingleton<IBookingStore>(new BookingFileStore(dataDirectory));


var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();



app.Run();


