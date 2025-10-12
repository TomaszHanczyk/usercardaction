using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UserCard.BL;
using UserCard.Common.PublicInterfaces;
using UserCard.DAL;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddScoped<IUserCardDao, UserCardDao>();
builder.Services.AddScoped<IUserCardBL, UserCardBL>();
builder.Services.AddScoped<IActionsCardDao, ActionsCardDao>();
builder.Services.AddScoped<IActionsCardBL, ActionsCardBL>();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c => {
	c.SwaggerDoc("v1", new()
	{
		Title = "UserCard.WebAPI",
		Version = "v1"
	});
	c.UseInlineDefinitionsForEnums();
});
var app = builder.Build();
// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
	app.UseSwagger();
	app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UserCard.WebAPI v1"));
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();