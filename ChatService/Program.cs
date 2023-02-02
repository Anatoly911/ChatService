using ChatService.Hubs;
using ChatService.Services;
using ChatService.Services.Impl;

namespace ChatService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddSignalR();
            builder.Services.AddSingleton<IMessageService, MessageService>();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseAuthorization();
            app.MapControllers();
            app.MapHub<MessageHub>("/hub/messages");
            app.Run();
        }
    }
}