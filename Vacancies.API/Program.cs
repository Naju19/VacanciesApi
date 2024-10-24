using System.Text.Json.Serialization;
using Vacancies.Core;
using Vacancies.Infrastructure.Repositories;
using Vacancies.Services.Mapper;
using Vacancies.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers()
    .AddJsonOptions(options =>
{ options.JsonSerializerOptions.PropertyNameCaseInsensitive = false;
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var sqlConnectionString = builder.Configuration.GetConnectionString("SqlServer");
builder.Services.AddSqlServer<VacancyDbContext>(sqlConnectionString);

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IVacancyRepository, VacancyRepository>();
builder.Services.AddTransient<IQuestionRepository, QuestionRepository>();
builder.Services.AddTransient<IAnswersRepository, AnswerRepository>();
builder.Services.AddTransient<IOptionRepository, OptionRepository>();
builder.Services.AddTransient<IApplicantRepository, ApplicantRepository>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IVacancyService, VacancyService>();
builder.Services.AddTransient<IQuestionService, QuestionService>();
builder.Services.AddTransient<IAnswerService, AnswerService>();
builder.Services.AddTransient<IApplicantService, ApplicantService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
