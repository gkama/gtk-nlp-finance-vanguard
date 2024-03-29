﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;

using nlp.finance.vanguard.data;
using nlp.finance.vanguard.services;

namespace nlp.finance.vanguard
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IModel<VanguardModel>>(Models.vanguard_model);
            services.AddScoped<INlpRepository<VanguardModel>, NlpRepository<VanguardModel>>();
            services.AddScoped<VanguardModelType>();
            services.AddScoped<CategoryType>();
            services.AddScoped<MatchedType>();
            services.AddScoped<NlpSchema>();
            services.AddScoped<NlpQuery>();

            services.AddLogging();
            services.AddHealthChecks();

            //GraphQL
            services.AddScoped<IDependencyResolver>(x => new FuncDependencyResolver(x.GetRequiredService));
            services.AddGraphQL(x => { x.ExposeExceptions = false; })
                .AddGraphTypes(ServiceLifetime.Scoped);

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(o =>
                {
                    o.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
                    o.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphQL<NlpSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());

            app.UseHealthChecks("/nlp/finance/vanguard/ping");
            app.UseMvc();
        }
    }
}
