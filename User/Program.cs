
using Google.Api;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using User.Adapters;
using User.Interfaces;
using User.Persistence;

namespace User
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.AddServiceDefaults();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //builder.Services.AddDbContext<AppDbContext>(ctx => { ctx.UseInMemoryDatabase("UserDb"); });


            //TODO: Further define the authentication requirement.
            //Preference would be to use Federated Identity provider / OIDC
            //builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);

            ////Redacted credentials
            //builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
            //    .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"));
            //builder.Services.AddAuthorization();

            builder.Services.AddTransient<IUserSvc, Services.UserSvc>();
            builder.Services.AddTransient<IProductSvcAdapter, ProductSvcAdapter>();

            builder.Services.AddDaprClient();

            var app = builder.Build();

            app.MapDefaultEndpoints();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            //redacted credentials from configuration
            //app.UseAuthentication();
            app.UseAuthorization();
            

            app.MapControllers();

            app.Run();
        }
    }
}
