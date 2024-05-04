var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
//app.UseHttpsRedirection();
var schools = new List<School>();

app.MapGet("/schools", () => schools);
app.MapGet("/schools/{id}", (int id) => schools.FirstOrDefault(h => h.Id == id));
app.MapPost("/schools", (School school) => schools.Add(school));
app.MapPut("/schools", (School school) => {
    var index = schools.FindIndex(h => h.Id == school.Id);
    if (index < 0)
    {
        throw new Exception("Not found");
    }
    schools[index] = school;
});
app.MapDelete("/schools/{id}", (int id) => {
    var index = schools.FindIndex(h => h.Id == id);
    if (index < 0) throw new Exception("Not found");
    schools.RemoveAt(index);
});


app.Run();



public class School
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}