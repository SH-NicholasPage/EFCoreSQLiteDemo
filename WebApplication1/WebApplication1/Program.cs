namespace SQLiteEFDemo
{
    public class Program
    {
        public static void Main(String[] args)
        {
            using (var client = new DBContext())
            {
                client.Database.EnsureCreated();
                client.FillTablesWithDemoInfo();
            }

            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddCors();

            WebApplication app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment() == false)
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseHttpsRedirection()
                .UseStaticFiles()
                .UseDefaultFiles()
                .UseRouting()
                .UseAuthorization();
            
            app.MapRazorPages();
            app.MapControllers();

            app.Run();
        }
    }
}