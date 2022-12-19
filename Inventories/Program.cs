internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        builder.Services.AddSession(options =>
        {
            options.Cookie.Name = "noteapp.session";//web sayfam�zda kullanaca��m�z ve session da tutulacak ismi belirledik.Herhangi bir �ey yaz�labilir.
            options.IdleTimeout = TimeSpan.FromMinutes(5); //5 dk i�lem yap�lmaz ise session� s�f�rlad�k
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
        }
        app.UseSession(); //gelen isteklerde bu session� aktifle�tir.
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}