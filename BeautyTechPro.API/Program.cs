using BeautyTechPro.Infrastructure.Data;
using BeautyTechPro.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Add services to the container
builder.Services.AddControllers();

// 🔹 DbContext (IMPORTANTE)
builder.Services.AddDbContext<BeautyTechProContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// 🔹 Repositories
builder.Services.AddScoped<StudentRepository>();
builder.Services.AddScoped<ModuleRepository>();
builder.Services.AddScoped<PracticeRepository>();
builder.Services.AddScoped<InstructorRepository>();
builder.Services.AddScoped<ScheduleRepository>();

// 🔹 Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 🔹 Configure pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseAuthorization();

try
{
    app.MapControllers();
}
catch (System.Reflection.ReflectionTypeLoadException ex)
{
    var errores = string.Join("\n\n", ex.LoaderExceptions.Select(e => e?.Message));

    throw new Exception("ERRORES REALES AL CARGAR CONTROLLERS:\n\n" + errores);
}

app.Run();