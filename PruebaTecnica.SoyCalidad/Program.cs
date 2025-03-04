using PruebaTecnica.SoyCalidad.Application;
using PruebaTecnica.SoyCalidad.Domain.Interfaces;
using PruebaTecnica.SoyCalidad.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Add services to the container.
//servicios
var conn = builder.Configuration.GetConnectionString("SQLServerConn");
builder.Services.AddTransient<IContainerCadenaConexion>(x => new ContainerCadenaConexion(conn)); //preparamos la inyeccion de dependencia
builder.Services.AddTransient<IAsignaturaRepo, AsignaturaRepo>();
builder.Services.AddTransient<IAsignaturasService, AsignaturasService>();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});
app.UseAuthorization();

app.MapRazorPages();

app.Run();
