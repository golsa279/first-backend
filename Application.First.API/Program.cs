using Application.First.API.DB;
using Application.First.API.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<FirstDB>(options=>
{
    options.UseSqlServer(@"server=(localdb)\MSSQLLocalDB;Database=ApplicationFirstDB;Trusted_Connection=True");

});
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.MapPost("/students/add",(FirstDB db,Student student)=>{
  db.Students.Add(student);
  db.SaveChanges();  
});
app.MapPost("/students/list",(FirstDB db)=>{
    return db.Students.ToList();
});
app.MapPost("/students/update",(FirstDB db,Student student)=>{
    db.Students.Update(student);
    db.SaveChanges();
});
app.MapPost("/Student/remove/{id}",(FirstDB db,int id)=>{
    var student=db.Students.Find(id);
    if(student!=null){
        db.Students.Remove(student);
        db.SaveChanges();
    }
});

app.Run();

