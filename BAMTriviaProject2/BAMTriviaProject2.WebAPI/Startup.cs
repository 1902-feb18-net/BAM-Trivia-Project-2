using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BAMTriviaProject2.DAL;
using BAMTriviaProject2.DAL.Repositories;
using BLL.Library.IRepositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace BAMTriviaProject2.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // from https://docs.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-2.2 to set up CORS
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // adds CORS services to the app's service container:
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    //builder.WithOrigins("http://localhost:4200",
                    //                    "http://www.someExample.com");
                    builder.WithOrigins("http://localhost:4200");
                        //.AllowAnyHeader()
                        //.AllowAnyMethod();
                });
            });

            services.AddScoped<IUsersRepo, UsersRepo>();

            // add question into scope
            services.AddScoped<IQuestionRepo, QuestionRepo>();
            // add answers into scope
            services.AddScoped<IAnswersRepo, AnswersRepo>();

            services.AddScoped<IQuizRepo, QuizRepo>();
            services.AddScoped<IQuizQuestionsRepo, QuizQuestionsRepo>();
            services.AddScoped<IAnswersRepo, AnswersRepo>();

            services.AddSingleton<IMapper, Mapper>();

            services.AddDbContext<BAMTriviaProject2Context>(builder =>
                builder.UseSqlServer(Configuration.GetConnectionString("BAMTriviaProject2")));

            services.AddDbContext<AuthDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("AuthDb")));

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                // we could just use defaults and not set anything on options
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                // many options here
            })
                .AddEntityFrameworkStores<AuthDbContext>();

            var cookieName = Configuration["AuthCookieName"];
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = Configuration["AuthCookieName"];
                options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                options.Events = new CookieAuthenticationEvents
                {
                    OnRedirectToLogin = context =>
                    {
                        // prevent redirect, just return unauthorized
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        context.Response.Headers.Remove("Location");
                        // we use Task.FromResult when we're in an async context
                        // but there's nothing to await.
                        return Task.FromResult(0);
                    },
                    OnRedirectToAccessDenied = context =>
                    {
                        // prevent redirect, just return forbidden
                        context.Response.StatusCode = StatusCodes.Status403Forbidden;
                        context.Response.Headers.Remove("Location");
                        // we use Task.FromResult when we're in an async context
                        // but there's nothing to await.
                        return Task.FromResult(0);
                    }
                };
            });

            services.AddAuthentication();

            services.AddMvc(options =>
            {
                options.ReturnHttpNotAcceptable = true;
            })
                .AddXmlSerializerFormatters()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(MyAllowSpecificOrigins); 

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
