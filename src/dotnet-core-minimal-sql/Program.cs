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
/// 
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

app.MapPost("/employees", async (Employee employee, ApiDbContext db) =>
{
    db.Employees.Add(employee);
    await db.SaveChangesAsync();
    return Results.Created($"/employees/{employee.Id}", employee);
}).Produces<Contact>(StatusCodes.Status201Created)
.WithName("PostEmployee").WithTags("Employees");

app.MapPut("/employees/{id}", async (int id, Employee inEmployee, ApiDbContext db) =>
{
    var employee = await db.Employees.FindAsync(id);
    if (employee is null) return Results.NotFound();
    employee.DisplayName = inEmployee.DisplayName;
    await db.SaveChangesAsync();
    return Results.NoContent();
}).Produces<Employee>(StatusCodes.Status204NoContent)
.WithName("PutEmployee").WithTags("Employees");

app.MapDelete("/employees/{id}", async (int id, ApiDbContext db) =>
{
    if (await db.Employees.FindAsync(id) is Employee employee)
    {
        db.Employees.Remove(employee);
        await db.SaveChangesAsync();
        return Results.Ok(employee);
    }
    return Results.NotFound();
}).Produces<Employee>(StatusCodes.Status204NoContent)
.WithName("DeleteEmployee").WithTags("Employees");
#endregion

#region Group CRUD
app.MapGet("/groups", async (ApiDbContext db) =>
 await db.Groups.ToListAsync()
).Produces<Group>(StatusCodes.Status200OK)
.WithName("GetGroups").WithTags("Groups");

app.MapGet("/groups/{id}", async (ApiDbContext db, int id) =>
    await db.Groups.SingleOrDefaultAsync(s => s.Id == id) is Group group ? Results.Ok(group) : Results.NotFound()
).Produces<Group>(StatusCodes.Status200OK)
.WithName("GetGroupById").WithTags("Groups");

app.MapPost("/groups", async (Group group, ApiDbContext db) =>
{
    db.Groups.Add(group);
    await db.SaveChangesAsync();
    return Results.Created($"/groups/{group.Id}", group);
}).Produces<Group>(StatusCodes.Status201Created)
.WithName("PostGroup").WithTags("Groups");

app.MapPut("/groups/{id}", async (int id, Group inGroup, ApiDbContext db) =>
{
    var group = await db.Groups.FindAsync(id);
    if (group is null) return Results.NotFound();
    group.DisplayName = inGroup.DisplayName;
    await db.SaveChangesAsync();
    return Results.NoContent();
}).Produces<Group>(StatusCodes.Status204NoContent)
.WithName("PutGroup").WithTags("Groups");

app.MapDelete("/groups/{id}", async (int id, ApiDbContext db) =>
{
    if (await db.Groups.FindAsync(id) is Group group)
    {
        db.Groups.Remove(group);
        await db.SaveChangesAsync();
        return Results.Ok(group);
    }
    return Results.NotFound();
}).Produces<Group>(StatusCodes.Status204NoContent)
.WithName("DeleteGroup").WithTags("Groups");
#endregion

#region EmployeeGroupAssoc CRUD
app.MapGet("/employeegroupassocs", async (ApiDbContext db) =>
 await db.EmployeeGroupAssocs.ToListAsync()
).Produces<EmployeeGroupAssoc>(StatusCodes.Status200OK)
.WithName("GetEmployeeGroupAssocs").WithTags("EmployeeGroupAssocs");

app.MapGet("/employeegroupassocs/{id}", async (ApiDbContext db, int id) =>
    await db.EmployeeGroupAssocs.SingleOrDefaultAsync(s => s.Id == id) is EmployeeGroupAssoc employeegroupassoc ? Results.Ok(employeegroupassoc) : Results.NotFound()
).Produces<EmployeeGroupAssoc>(StatusCodes.Status200OK)
.WithName("GetEmployeeGroupAssocsById").WithTags("EmployeeGroupAssocs");

app.MapGet("/employeegroupassocs/employeeid/{employeeid}/group/{groupid}", async (ApiDbContext db, int employeeid, int groupid) =>
    await db.EmployeeGroupAssocs.SingleOrDefaultAsync(s => s.EmployeeId == employeeid && s.GroupId == groupid) is EmployeeGroupAssoc employeegroupassoc ? Results.Ok(employeegroupassoc) : Results.NotFound()
).Produces<EmployeeGroupAssoc>(StatusCodes.Status200OK)
.WithName("GetEmployeeGroupAssocsByEmployeeAndGroupId").WithTags("EmployeeGroupAssocs");

app.MapPost("/employeegroupassocs", async (EmployeeGroupAssoc employeegroupassoc, ApiDbContext db) =>
{
    db.EmployeeGroupAssocs.Add(employeegroupassoc);
    await db.SaveChangesAsync();
    return Results.Created($"/employeegroupassocs/{employeegroupassoc.Id}", employeegroupassoc);
}).Produces<EmployeeGroupAssoc>(StatusCodes.Status201Created)
.WithName("PostEmployeeGroupAssoc").WithTags("EmployeeGroupAssocs");

app.MapDelete("/employeegroupassocs/{id}", async (int id, ApiDbContext db) =>
{
    if (await db.EmployeeGroupAssocs.FindAsync(id) is EmployeeGroupAssoc employeegroupassoc)
    {
        db.EmployeeGroupAssocs.Remove(employeegroupassoc);
        await db.SaveChangesAsync();
        return Results.Ok(employeegroupassoc);
    }
    return Results.NotFound();
}).Produces<EmployeeGroupAssoc>(StatusCodes.Status204NoContent)
.WithName("DeleteEmployeeGroupAssoc").WithTags("EmployeeGroupAssocs");
#endregion

app.Run();