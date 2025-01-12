using Autofac.Extensions.DependencyInjection;
using Autofac;
using Busines.DependencyResolvers.Autofac;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json.Serialization;
using WebAPI;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// CORS ayarlarý
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.WithOrigins("http://localhost:4200") // Angular URL
              .AllowAnyMethod()                    // Tüm HTTP yöntemleri
              .AllowAnyHeader()                    // Tüm baþlýklar
              .AllowCredentials();                 // Kimlik doðrulama ve çerezler
    });
});

// JSON ayarlarý
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.MaxDepth = 128;
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});



// Autofac ve baðýmlýlýk enjeksiyonu
builder.Host
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutofacBusinessModule());
    });

// Swagger ve API dökümantasyonu
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });

    // Dosya yüklemeleri için Swagger desteði
    options.OperationFilter<SwaggerFileOperationFilter>();
});


// DataAccess servislerini ekle
builder.Services.AddDataAccessServices();

// HTTP eriþimi için servis
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// JWT doðrulama ayarlarý
var configuration = builder.Configuration;
var tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };
    });

var app = builder.Build();

// Geliþtirme ortamý ayarlarý
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Hata detaylarýný göster
    app.UseSwagger();
    app.UseSwaggerUI();
}

// CORS ayarlarýný etkinleþtir
app.UseCors("AllowAllOrigins");

// HTTP yönlendirme ve dosya eriþimi
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Kimlik doðrulama ve yetkilendirme
app.UseAuthentication();
app.UseAuthorization();

// Controller'larý eþleþtir
app.MapControllers();

// Uygulamayý çalýþtýr
app.Run();
