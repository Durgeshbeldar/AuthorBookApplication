
using AuthorBookApplication.Data;
using AuthorBookApplication.Repositories;
using AuthorBookApplication.Services;
using Microsoft.EntityFrameworkCore;

namespace AuthorBookApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<AuthorBookContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("ConnString"));
            });

            builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddTransient<IBookService,BookService>();
            builder.Services.AddTransient<IBookRepository,BookRepository>();
            builder.Services.AddTransient<IAuthorService, AuthorService>();
            builder.Services.AddTransient<IAuthorRepository, AuthorRepository>();
            builder.Services.AddTransient<IAuthorDetailsService, AuthorDetailsService>();
            builder.Services.AddTransient<IAuthorDetailsRepository, AuthorDetailsRepository>();

            builder.Services.AddControllers();
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


            app.MapControllers();

            app.Run();
        }
    }
}
