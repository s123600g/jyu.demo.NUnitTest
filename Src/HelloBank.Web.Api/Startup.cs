using HelloBank.Web.Api.Filters;
using HelloBank.Web.Api.Services;
using HelloBankDbLib.Dao;
using Microsoft.EntityFrameworkCore;

namespace HelloBank.Web.Api;

public class Startup
{
    public IConfiguration _configuration { get; }
    
    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        services.AddDbContext<HelloBankDbContext>(opt =>
        {
            var dbConnStr = _configuration.GetConnectionString(name: "HelloBankDb");

            if (string.IsNullOrEmpty(dbConnStr))
            {
                throw new ArgumentNullException(nameof(dbConnStr));
            }

            opt.UseSqlite(connectionString: dbConnStr);
        });
        
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        
        services.AddSwaggerGen(optios =>
        {
            #region 設置Swagger 項目過濾器

            // 註冊Api分群項目過濾器
            optios.OperationFilter<TagByAreaNameOperationFilter>();

            #endregion
        });

        services.AddCoreServices();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Configure the HTTP request pipeline.
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        
        app.UseRouting();
        
        app.UseEndpoints(endpoints =>
        {
            // 設定Api路由樣式匹配規則
            endpoints.MapControllerRoute(
                name: "ApiArea",
                pattern: "{area:exists}/{controller}/{action}"
            );
        });
        
        app.UseHttpsRedirection();
    }
}