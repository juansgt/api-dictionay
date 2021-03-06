﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDictionary.Model.DataAccess.PropertyDao;
using ApiDictionary.Model.DataAccess.PropertyDao.PropertyDaoMongo;
using ApiDictionary.Model.Services.DictionaryService;
using ApiDictionary.Services.PropertyService;
using Criteria;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ApiDictionary
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddTransient<IPropertyService, PropertyServiceProxy>();
            services.AddTransient<IDictionaryService, DictionaryService>();
            var mongoClient = new MongoClient("mongodb://172.17.0.2:27017");
            var mongoDatabase = mongoClient.GetDatabase("dictionary");
            services.AddTransient<IPropertyDao>(s => new PropertyDaoMongoImpl(mongoClient, mongoDatabase));
            //services.AddTransient<IPropertyDao, PropertyDaoMongoImpl>();
            //services.AddTransient<>
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
