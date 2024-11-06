using ETIGRTEC.Services;

var builder = WebApplication.CreateBuilder(args);

// REGISTRAR EL PRODUCT SERVICES PARA LAS PETICIONES DE URL
builder.Services.AddScoped<ProductService>();

// REGIISTRAR CONTROLADORES
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configuración de la aplicación (middleware)
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
