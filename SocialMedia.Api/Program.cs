using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Interfaces;
using SocialMedia.Core.Services;
using SocialMedia.Infraestructure.Data;
using SocialMedia.Infraestructure.Filters;
using SocialMedia.Infraestructure.Interfaces;
using SocialMedia.Infraestructure.Repositories;
using SocialMedia.Infraestructure.Validators;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

/*options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true // Con esta linea de código conseguimos que todos los campos de los modelos acepten valores nulos*/ 
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore; // para evitar el error de referencia circular
    }).ConfigureApiBehaviorOptions(options =>
    {
        //options.SuppressModelStateInvalidFilter = true; /*Esto funciona para desactivar las validaciones de modelos que hace el decorador [apiController] en el controlador*/
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IPostService, PostService>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
//builder.Services.AddTransient<IUserRepository, UserRepository>();
//builder.Services.AddTransient<IPostRepository, PostRepository>(); // Aqui se da a entender que abstracción se va usar con la implementación
// siendo IPostRepository la abstracción y PostRepository la implementación 

builder.Services.AddDbContext<SocialMediaContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SocialMedia"));
});

builder.Services.AddMvc(options =>
{
    options.Filters.Add<ValidationFilter>();
}).AddFluentValidation(options => {
    options.RegisterValidatorsFromAssemblyContaining<PostValidator>();
});


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
