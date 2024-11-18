using BankLiteBack.Data;
using BankLiteBack.Interfaces;
using BankLiteBack.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

//SQL連線字串
builder.Services.AddDbContext<DefaultContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultContext")));


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Service & Interface
builder.Services.AddScoped<IUsersService, UsersService>();//使用者帳號相關
builder.Services.AddScoped<ILoginService, LoginService>();//使用者登入
builder.Services.AddScoped<IAccountsServices, AccountsService>();//帳戶相關
builder.Services.AddScoped<IAccountTypesService, AccountTypesService>();//帳戶類型
builder.Services.AddScoped<IFilesService, FilesService>();//檔案相關
builder.Services.AddScoped<ITransactionsService, TransactionsService>();//交易紀錄相關

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
