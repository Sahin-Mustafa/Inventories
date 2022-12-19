internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        builder.Services.AddSession(options =>
        {
            options.Cookie.Name = "noteapp.session";//web sayfamýzda kullanacaðýmýz ve session da tutulacak ismi belirledik.Herhangi bir þey yazýlabilir.
            options.IdleTimeout = TimeSpan.FromMinutes(5); //5 dk iþlem yapýlmaz ise sessioný sýfýrladýk
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
        }
        app.UseSession(); //gelen isteklerde bu sessioný aktifleþtir.
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}