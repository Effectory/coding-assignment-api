using EasyNetQ;
using Effectory.Services.Questionnaire.Handlers;
using Effectory.Services.Questionnaire.Messages;
using Effectory.Services.Questionnaire.Providers;
using Effectory.Services.Questionnaire.Repositories;
using Effectory.Services.Questionnaire.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace Effectory.Services.Questionnaire
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
               .AddApiVersioning(options =>
               {
                   options.ReportApiVersions = true;
                   options.AssumeDefaultVersionWhenUnspecified = true;
               })
               .AddVersionedApiExplorer(options =>
               {
                   options.GroupNameFormat = "'v'V";
                   options.SubstituteApiVersionInUrl = true;
               });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Effectory.Services.Questionnaire", Version = "v1" });
            });

            services.AddScoped<IUserContext, UserContext>();
            services.AddTransient<IQuestionnaireRepository, QuestionnaireRepository>();
            services.AddSingleton<IDataSource, DataSource>();
            services.AddTransient<IHandler<TextAnswerMessage>, TextAnswerMessageHandler>();
            services.AddTransient<IHandler<SingleChoiceAnswerMessage>, SingleChoiceAnswerMessageHandler>();

            var rabbitMqSettings = Configuration.GetSection(nameof(RabbitMqSettings)).Get<RabbitMqSettings>();
            services.AddSingleton(RabbitHutch.CreateBus(rabbitMqSettings.ConnectionString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Effectory.Services.Questionnaire v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            var bus = app.ApplicationServices.GetRequiredService<IBus>();
            bus.PubSub.SubscribeAsync<TextAnswerMessage>(Guid.NewGuid().ToString(), m => app.ApplicationServices.GetRequiredService<IHandler<TextAnswerMessage>>().Handle(m));
            bus.PubSub.SubscribeAsync<SingleChoiceAnswerMessage>(Guid.NewGuid().ToString(), m => app.ApplicationServices.GetRequiredService<IHandler<SingleChoiceAnswerMessage>>().Handle(m));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
