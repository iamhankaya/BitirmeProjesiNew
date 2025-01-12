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

// CORS ayarlar�
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.WithOrigins("http://localhost:4200") // Angular URL
              .AllowAnyMethod()                    // T�m HTTP y�ntemleri
              .AllowAnyHeader()                    // T�m ba�l�klar
              .AllowCredentials();                 // Kimlik do�rulama ve �erezler
    });
});

// JSON ayarlar�
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.MaxDepth = 128;
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});



// Autofac ve ba��ml�l�k enjeksiyonu
builder.Host
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutofacBusinessModule());
    });

// Swagger ve API d�k�mantasyonu
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });

    // Dosya y�klemeleri i�in Swagger deste�i
    options.OperationFilter<SwaggerFileOperationFilter>();
});


// DataAccess servislerini ekle
builder.Services.AddDataAccessServices();

// HTTP eri�imi i�in servis
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// JWT do�rulama ayarlar�
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

// Geli�tirme ortam� ayarlar�
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Hata detaylar�n� g�ster
    app.UseSwagger();
    app.UseSwaggerUI();
}

// CORS ayarlar�n� etkinle�tir
app.UseCors("AllowAllOrigins");

// HTTP y�nlendirme ve dosya eri�imi
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Kimlik do�rulama ve yetkilendirme
app.UseAuthentication();
app.UseAuthorization();

// Controller'lar� e�le�tir
app.MapControllers();

// Uygulamay� �al��t�r
app.Run();
