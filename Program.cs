using FrameWork.Custom;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using OpenFin_User_Management_WebApi.IServices;
using OpenFinanceWebApi.Custom;
using OpenFinanceWebApi.IServices;
using OpenFinanceWebApi.Models;
using OpenFinanceWebApi.NLogService;
using OpenFinanceWebApi.Services;
using Raqmiyat.Framework.Model;
using System.Data;
using System.Data.SqlClient;
using UserAccessService.IServices;
using UserAccessService.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<RedHatMQParams>(builder.Configuration.GetSection("RedHatMQParams"));


builder.Services.AddTransient<HttpClientHandler>();
builder.Services.AddHttpClient("HttpClient")
    .ConfigurePrimaryHttpMessageHandler(
        () => new HttpClientHandler()
        {
            ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
        }
    );

builder.Services.Configure<BankData>(builder.Configuration.GetSection("BankData"));
builder.Services.Configure<SignatureParams>(builder.Configuration.GetSection("SignatureParams"));
builder.Services.Configure<ServiceParams>(builder.Configuration.GetSection("ServiceParams"));
builder.Services.Configure<DataBaseConnectionParams>(builder.Configuration.GetSection("DataBaseConnectionParams"));

builder.Services.AddSingleton<NLogWebApiService>();
builder.Services.AddSingleton<MQLog>();

builder.Services.AddSingleton<IDbConnection>(provider =>
{
    IDbConnection? dbConnection = null;

    var dBConparam = builder.Configuration.GetSection(nameof(DataBaseConnectionParams)).Get<DataBaseConnectionParams>();
    var conString = SqlConManager.GetConnectionString(dBConparam!.AuditLogConnection!, dBConparam.IsEncrypted);
    if (!conString.Contains("MultipleActiveResultSets"))
    {
        conString = $"{conString}MultipleActiveResultSets=True";
    }
    dbConnection = new SqlConnection(conString);
    if (dbConnection.State == ConnectionState.Open)
    {
        dbConnection.Close();
    }
    if (dbConnection.State == ConnectionState.Closed)
    {
        dbConnection.Open();
    }
    return dbConnection!;
});

// Add services to the container.

builder.Services.AddTransient<ILoginService, LoginService>();
builder.Services.AddTransient<IHomeService, HomeService>();
builder.Services.AddTransient<IAssignRoleMakerService, AssignRoleMakerService>();
builder.Services.AddTransient<IAssignRoleCheckerService, AssignRoleCheckerService>();
builder.Services.AddTransient<ITransactionAccessMakerService, TransactionAccessMakerService>();
builder.Services.AddTransient<ITransactionAccessCheckerService, TransactionAccessCheckerService>();
builder.Services.AddTransient<IBankConfigurationMakerService, BankConfigurationMakerService>();
builder.Services.AddTransient<IBankConfigurationCheckerService, BankConfigurationCheckerService>();
builder.Services.AddTransient<IUserCreationService, UserCreationService>();
builder.Services.AddTransient<IRoleCheckerService, RoleCheckerService>();
builder.Services.AddTransient<IRoleMakerService, RoleMakerService>();
builder.Services.AddTransient<ILogMoniterService, LogMoniterService>();
builder.Services.AddTransient<IPasswordPolicyService, PasswordPolicyService>();
builder.Services.AddTransient<IChangePasswordService, ChangePasswordService>();
builder.Services.AddTransient<IGeneralService, GeneralService>();
builder.Services.AddTransient<IChargeMasterMakerService, ChargeMasterMakerService>();
builder.Services.AddTransient<ICountryMasterMakerService, CountryMasterMakerService>();
builder.Services.AddTransient<IBankOnboardingService, BankOnboardingService>();
builder.Services.AddTransient<IEmailGroupMasterService, EmailGroupMasterService>();
builder.Services.AddTransient<IErrorMasterService, ErrorMasterService>();
builder.Services.AddTransient<IAdmi004Service, Admi004Service>();
builder.Services.AddTransient<IReports, Reports>();
builder.Services.AddTransient<IConsentBulkService, ConsentBulkService>();
builder.Services.AddTransient<IProductMasterService, ProductMasterService>();
builder.Services.AddTransient<IDataValidateService, DataValidateService>();


var AllowSpecificOrigins = "OpenFinance";
builder.Services.AddCors(options => { options.AddPolicy(name: AllowSpecificOrigins, builder => { builder.AllowAnyOrigin().AllowAnyHeader(); }); });
bool isEncrypted = builder.Configuration.GetValue<bool>("DataBaseConnectionParams:IsEncrypted");

string encryptedConnectionString = builder.Configuration.GetValue<string>("DataBaseConnectionParams:DBConnection") ?? "";

if (string.IsNullOrEmpty(encryptedConnectionString))
{
    throw new InvalidOperationException("Encrypted connection string is null or empty.");
}

string decryptedConnectionString = isEncrypted ? SqlConManager.Decrypt(encryptedConnectionString) : encryptedConnectionString;

builder.Services.AddStackExchangeRedisCache(options => { options.Configuration = builder.Configuration["RedisCacheUrl"]; });

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHealthChecks();

var app = builder.Build();
app.UseCors(AllowSpecificOrigins);

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/health", new HealthCheckOptions()
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

await app.RunAsync();
