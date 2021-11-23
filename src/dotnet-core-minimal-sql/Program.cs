using API.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApiDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnectionString"));
});

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

/// <summary>
///   Map Operations
/// </summary>
#region Contact CRUD
app.MapGet("/contacts", async (ApiDbContext db) =>
 await db.Contacts.ToListAsync()
).Produces<Contact>(StatusCodes.Status200OK)
.WithName("GetContacts").WithTags("Contacts");

app.MapGet("/contacts/{id}", async (ApiDbContext db, int id) =>
    await db.Contacts.SingleOrDefaultAsync(s => s.Id == id) is Contact contact ? Results.Ok(contact) : Results.NotFound()
).Produces<Contact>(StatusCodes.Status200OK)
.WithName("GetContactById").WithTags("Contacts");

app.MapPost("/contacts", async (Contact contact, ApiDbContext db) =>
{
    db.Contacts.Add(contact);
    await db.SaveChangesAsync();
    return Results.Created($"/contacts/{contact.Id}", contact);
}).Produces<Contact>(StatusCodes.Status201Created)
.WithName("PostContact").WithTags("Contacts");

app.MapPut("/contacts/{id}", async (int id, Contact inContact, ApiDbContext db) =>
{
    var contact = await db.Contacts.FindAsync(id);
    if (contact is null) return Results.NotFound();
    contact.DisplayName = inContact.DisplayName;
    await db.SaveChangesAsync();
    return Results.NoContent();
}).Produces<Contact>(StatusCodes.Status204NoContent)
.WithName("PutContact").WithTags("Contacts");

app.MapDelete("/contacts/{id}", async (int id, ApiDbContext db) =>
{
    if (await db.Contacts.FindAsync(id) is Contact contact)
    {
        db.Contacts.Remove(contact);
        await db.SaveChangesAsync();
        return Results.Ok(contact);
    }
    return Results.NotFound();
}).Produces<Contact>(StatusCodes.Status204NoContent)
.WithName("DeleteContact").WithTags("Contacts");
#endregion

#region Employee CRUD
app.MapGet("/employees", async (ApiDbContext db) =>
 await db.Employees.ToListAsync()
).Produces<Employee>(StatusCodes.Status200OK)
.WithName("GetEmployees").WithTags("Employees");

app.MapGet("/employees/{id}", async (ApiDbContext db, int id) =>
    await db.Employees.SingleOrDefaultAsync(s => s.Id == id) is Employee employee ? Results.Ok(employee) : Results.NotFound()
).Produces<Employee>(StatusCodes.Status200OK)
.WithName("GetEmployeeById").WithTags("Employees");
#endregion

#region Contact CRUD
app.MapGet("/groups", async (ApiDbContext db) =>
 await db.Groups.ToListAsync()
).Produces<Group>(StatusCodes.Status200OK)
.WithName("GetGroups").WithTags("Groups");

app.MapGet("/groups/{id}", async (ApiDbContext db, int id) =>
    await db.Groups.SingleOrDefaultAsync(s => s.Id == id) is Group group ? Results.Ok(group) : Results.NotFound()
).Produces<Group>(StatusCodes.Status200OK)
.WithName("GetGroupById").WithTags("Groups");
#endregion

app.Run();