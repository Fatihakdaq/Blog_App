using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete;
using BlogApp.Data.Concrete.Efcore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(); // Controller'ların view ile ilişkilendirilmesi sağlanıyor.

// Veri tabanı bağlantı kurulumu - SQL Server
builder.Services.AddDbContext<BlogContext>(options =>
{
	options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]);
	// SQL Server kullanmayı belirtiyoruz ve appsettings.json dosyasındaki bağlantı dizesini kullanıyoruz.
});

// AddScoped: Her HTTP isteği başına bir nesne olarak gelir.
builder.Services.AddScoped<IPostRepository, EfPostRepository>();
builder.Services.AddScoped<ITagRepository, EfTagRepository>();
builder.Services.AddScoped<ICommentRepository, EfCommentRepository>();
builder.Services.AddScoped<IUserRepository, EfUserRepository>();

// Kimlik doğrulama ekleniyor.
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

var app = builder.Build();

// Middleware kullanımı
app.UseStaticFiles(); // Statik dosyalar kullanıma açılıyor.
app.UseRouting(); // Gelen istekleri Controller ve action methoduna yönlendirir.
app.UseAuthentication(); // Kimlik doğrulama işlemi yapılıyor.
app.UseAuthorization(); // Yetkilendirme işlemi yapılıyor.

// Seed Data - Test Verileri
SeedData.TestVerileriniDoldur(app);

// Routing
app.MapControllerRoute(
	name: "post_details",
	pattern: "posts/details/{url}",
	defaults: new { controller = "Posts", action = "Details" }
);

app.MapControllerRoute(
	name: "posts_by_tag",
	pattern: "posts/tag/{tag}",
	defaults: new { controller = "Posts", action = "Index" }
);

app.MapControllerRoute(
	name: "users_profile",
	pattern: "profile/{username}",
	defaults: new { controller = "Users", action = "Profile" }
);

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Posts}/{action=Index}/{id?}"
);

app.Run();
