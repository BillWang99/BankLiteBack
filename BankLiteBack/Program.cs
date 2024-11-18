using BankLiteBack.Data;
using BankLiteBack.Interfaces;
using BankLiteBack.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

//SQL�s�u�r��
builder.Services.AddDbContext<DefaultContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultContext")));


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Service & Interface
builder.Services.AddScoped<IUsersService, UsersService>();//�ϥΪ̱b������
builder.Services.AddScoped<ILoginService, LoginService>();//�ϥΪ̵n�J
builder.Services.AddScoped<IAccountsServices, AccountsService>();//�b�����
builder.Services.AddScoped<IAccountTypesService, AccountTypesService>();//�b������
builder.Services.AddScoped<IFilesService, FilesService>();//�ɮ׬���
builder.Services.AddScoped<ITransactionsService, TransactionsService>();//�����������

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
