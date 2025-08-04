using Infrastructure;
namespace System_For_Teacher_Academy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var presentationLayerAssembly = typeof(Presentation.AssemblyReference).Assembly;

            builder.Services.AddControllers()
                .AddApplicationPart(presentationLayerAssembly)
                .AddControllersAsServices();
            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(presentationLayerAssembly);
                cfg.RegisterServicesFromAssembly(typeof(Core.AssemblyReference).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(AssemblyReference).Assembly);

            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.applayInfrastructureService(builder.Configuration);



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
        }
    }
}
