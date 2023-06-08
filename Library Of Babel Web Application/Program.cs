using Microsoft.AspNetCore.Authentication.Cookies;
using Logic.Interfaces;
using DataLogic.DBs;
using Logic.Managers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages()
    .AddMvcOptions(options =>
    {
        options.MaxModelValidationErrors = 50;
        options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
            _ => "The field is required.");
    });

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
    options =>
    {
        options.Cookie.SameSite = SameSiteMode.None;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        options.Cookie.IsEssential = true;
        options.LoginPath = new PathString("/LogIn");
        options.LogoutPath = new PathString("/Index");
    }
);


builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


builder.Services.AddSingleton<IUserDB, UserDB>();
builder.Services.AddSingleton<IBookDB, BookDB>();
builder.Services.AddSingleton<IFavouriteBookDB, FavouriteBookDB>();
builder.Services.AddSingleton<IGenderTypeDB, GenderTypeDB>();
builder.Services.AddSingleton<IGenreDB, GenreDB>();
builder.Services.AddSingleton<IReviewDB, ReviewDB>();

builder.Services.AddScoped<UserManager>();
builder.Services.AddScoped<BookManager>();
builder.Services.AddScoped<FavouriteBookManager>();
builder.Services.AddScoped<GenderTypeManager>();
builder.Services.AddScoped<GenreManager>();
builder.Services.AddScoped<ReviewManager>();
builder.Services.AddScoped<RecommendationManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();

