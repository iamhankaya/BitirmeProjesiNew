using Busines.Abstract;
using Busines.Concrete;
using Business.Abstract;
using Business.Concrete;
using Business;
using Core.Utilities.Helpers.Abstract.ForFile;
using Core.Utilities.Helpers.Concrete.ForFile;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Repositories;
using DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

public static class ServiceRegistration
{
    public static void AddDataAccessServices(this IServiceCollection services)
    {
        services.AddDbContext<BitirmeETicaretDBContext>(options =>
        {
            options.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=BitirmeETicaretDB;Trusted_Connection=true;Pooling=false;");
            options.EnableSensitiveDataLogging();
            options.LogTo(Console.WriteLine, LogLevel.Information);
        }, ServiceLifetime.Transient);

        // Bağımlılık enjeksiyonu
        services.AddScoped<IProductReadRepository, ProductReadRepository>();
        services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
        services.AddScoped<IProductService, ProductManager>();

        services.AddScoped<IOrderReadRepository, OrderReadRepository>();
        services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
        services.AddScoped<IOrderService, OrderManager>();

        services.AddScoped<ICartReadRepository, CartReadRepository>();
        services.AddScoped<ICartWriteRepository, CartWriteRepository>();
        services.AddScoped<ICartService, CartManager>();

        services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
        services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
        services.AddScoped<ICategoryService, CategoryManager>();

        services.AddScoped<IPaymentReadRepository, PaymentReadRepository>();
        services.AddScoped<IPaymentWriteRepository, PaymentWriteRepository>();
        services.AddScoped<IPaymentService, PaymentManager>();

        services.AddScoped<IReviewReadRepository, ReviewReadRepository>();
        services.AddScoped<IReviewWriteRepository, ReviewWriteRepository>();
        services.AddScoped<IReviewService, ReviewManager>();

        services.AddScoped<IUserReadRepository, UserReadRepository>();
        services.AddScoped<IUserWriteRepository, UserWriteRepository>();
        services.AddScoped<IUserService, UserManager>();

        services.AddScoped<ICreditCardReadRepository, CreditCardReadRepository>();
        services.AddScoped<ICreditCardWriteRepository, CreditCardWriteRepository>();
        services.AddScoped<ICreditCardService, CreditCardManager>();

        services.AddScoped<IProductImageReadRepository, ProductImageReadRepository>();
        services.AddScoped<IProductImageWriteRepository, ProductImageWriteRepository>();
        services.AddScoped<IProductImageService, ProductImageManager>();

        services.AddScoped<ITokenHelper, JwtHelper>();
        services.AddScoped<IFileHelper, FileHelper>();
        services.AddScoped<IAuthService, AuthManager>();

        // Swagger için dosya yükleme desteği
        services.AddTransient<SwaggerFileOperationFilter>();

        // JSON ve problem details desteği
        services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.MaxDepth = 128;
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        });

        services.AddProblemDetails();

        // Cache desteği
        services.AddMemoryCache();
        services.AddResponseCaching();

        // Log desteği
        services.AddLogging(config =>
        {
            config.AddConsole();
            config.AddDebug();
        });
    }
}
