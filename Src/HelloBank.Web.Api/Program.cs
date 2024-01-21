using HelloBank.Web.Api.Filters;

namespace HelloBank.Web.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var services = builder.Services;

        services.AddControllers();

        // Add services to the container.
        services.AddAuthorization();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(optios =>
        {
            #region 設置Swagger 項目過濾器

            // 註冊Api分群項目過濾器
            optios.OperationFilter<TagByAreaNameOperationFilter>();

            #endregion
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
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

        app.Run();
    }
}