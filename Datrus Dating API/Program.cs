
using Datrus_Application.IRepositories;
using Datrus_Application.IServices;
using Datrus_Application.Services;
using Datrus_Domain.Entities;
using Datrus_Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Datrus_Dating_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });
            // Add services to the container.

            builder.Services.AddControllers();

            var connectionString = builder.Configuration.GetConnectionString("AWS_Server");
            builder.Services.AddDbContext<DatusDatingDb>(c => c.UseSqlServer(connectionString));

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IMatchRepository, UsersMatchRepository>();
            builder.Services.AddScoped<ILikesSentRepository, LikesSentRepository>();
            builder.Services.AddScoped<IUsersPreference, UsersPreferenceRepository>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseCors();


            app.MapControllers();

            app.Run();
        }
    }
}