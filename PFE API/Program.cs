using PFE_API;
using PFE_API.Controller;
using PFE_API.Model;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add services to the container.
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

app.MapGet("/getEmployees", () => EmployeeDbController.GetEmployees());

app.MapGet("/insertEmployee", (string nom) => {
    var newEmployee = new Employee
    {
        Matricule = "EMP002",
        NSS = "98765432109876",
        Nom = nom,
        Prenom = "Jane",
        Prenom2 = "Middle",
        NomArabe = "سميث",
        PrenomArabe = "جين",
        Prenom2Arabe = "ميدل",
        DateNaissance = new DateTime(1985, 5, 15, 0, 0, 0, DateTimeKind.Utc),
        NomJeuneFille = "Doe",
        LieuNaissance = "Los Angeles",
        PaysNaissance = "USA",
        WilayaNaissance = "California",
        CommuneNaissance = "Los Angeles",
        Sexe = "F",
        Titre = "Senior Manager",
        SituationFamiliale = "Married",
        Nationalites = "American",
        Telephone = "9876543210",
        Mobile = "1234567890",
        Email = "jane@example.com",
        Photo = new byte[] { /* photo byte array */ },
        Reliquat = 100,
        IsResponsable = false,
        IDEquipe = 2,
        IDResponsable = "EMP001"
    };


    EmployeeDbController.Insert(newEmployee); });  

app.MapControllers();

app.Run();