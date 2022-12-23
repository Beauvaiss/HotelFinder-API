using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.DataAccess.Abstrack;
using HotelFinder.DataAccess.Concrete;

namespace HotelFinderrr.API
{
    public class Program
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            
           
        }
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddSingleton<IHotelRepository, HotelRepository>();
            builder.Services.AddSingleton<IHotelService, HotelManager>();
            builder.Services.AddControllers();
            builder.Services.AddSwaggerDocument();
            builder.Services.AddRazorPages();
            var app = builder.Build();
            app.MapControllers();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseOpenApi();
            app.UseSwaggerUi3();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapRazorPages();
            app.Run();
        }
    }
}