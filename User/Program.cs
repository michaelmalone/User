
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using User.Interfaces;
using User.Persistence;

namespace User
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //builder.Services.AddDbContext<AppDbContext>(ctx => { ctx.UseInMemoryDatabase("UserDb"); });
            builder.Services.AddAuthorization();

            //TODO: Further define the authentication requirement.
            //Preference would be to use Federated Identity provider / OIDC
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);

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
