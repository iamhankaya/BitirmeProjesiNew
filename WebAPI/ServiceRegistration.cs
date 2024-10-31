
using Busines.Abstract;
using Busines.Concrete;
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public static class ServiceRegistration
    {
        public static void AddDataAccessServices(this IServiceCollection services)
        {
            services.AddDbContext<BitirmeETicaretDBContext>(options => options.
           UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=BitirmeETicaretDB;Trusted_Connection=true"));

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
            services.AddScoped<ICategoryService,CategoryManager>();

            services.AddScoped<IPaymentReadRepository, PaymentReadRepository>();
            services.AddScoped<IPaymentWriteRepository, PaymentWriteRepository>();
            services.AddScoped<IPaymentService,PaymentManager>();

            services.AddScoped<IReviewReadRepository, ReviewReadRepository>();
            services.AddScoped<IReviewWriteRepository, ReviewWriteRepository>();
            services.AddScoped<IReviewService,ReviewManager>();

            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();
            services.AddScoped<IUserService,UserManager>();

            services.AddScoped<ICreditCardReadRepository, CreditCardReadRepository>();
            services.AddScoped<ICreditCardWriteRepository, CreditCardWriteRepository>();
            services.AddScoped<ICreditCardService,CreditCardManager>();

            services.AddScoped<ITokenHelper,JwtHelper>();

            services.AddScoped<IAuthService, AuthManager>();
        }
    }
}
