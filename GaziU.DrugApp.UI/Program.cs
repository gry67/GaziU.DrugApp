using GaziU.DrugApp.BL.Abstract;
using GaziU.DrugApp.BL.Concrete;
using GaziU.DrugApp.DAL;
using GaziU.DrugApp.DAL.Repositories.Abstract;
using GaziU.DrugApp.DAL.Repositories.Concrete;
using GaziU.DrugApp.UI.Controllers;


namespace GaziU.DrugApp.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<AppDbContext>();

            builder.Services.AddScoped(typeof(BL.Abstract.IGenericManager<>), typeof(GenericManager<>));
            builder.Services.AddScoped<IHastaRepository, HastaRepository>();
            builder.Services.AddScoped<IDrugManager, DrugManager>();
            builder.Services.AddScoped<IDrugRepository, DrugRepository>();
            builder.Services.AddScoped<IDoktorRepository, DoktorRepository>();
            builder.Services.AddScoped(typeof(DAL.Repositories.Abstract.IGenericManager<>), typeof(GenericRepository<>));

            builder.Services.AddControllersWithViews();

            // Add authorization services
            builder.Services.AddAuthorization();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
        }
    }
}
