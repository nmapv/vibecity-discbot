using Discord.Commands;
using Discord.WebSocket;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using vibecity_discbot.repository.Repository.Base;
using vibecity_discbot.service.Service;

namespace vibecity_discbot.app
{
    class Program
    {
        private DiscordSocketClient _client;
        private CommandService _command;
        private IServiceProvider _service;

        static void Main(string[] args)
        => new Program().StartAsync().GetAwaiter().GetResult();

        public async Task StartAsync()
        {
            _client = new DiscordSocketClient();
            _command = new CommandService();       

            _service = new ServiceCollection()
                .AddSingleton(_client)
                .AddSingleton(_command)
                .AddSingleton<IDBContext, DBContext>()
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<IPointService, PointService>()
                .AddFluentMigratorCore()
                .ConfigureRunner(c => c
                    .AddSQLite()
                    .WithGlobalConnectionString("DataSource=file::memory:?cache=shared")
                    .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations())
                .AddLogging(c => c.AddFluentMigratorConsole())
                .BuildServiceProvider();

            using (var scope = _service.CreateScope())
            {
                UpdateDatabase(scope.ServiceProvider);
            }

            var token = Environment.GetEnvironmentVariable("token_disc");

            await RegisterCommandAsync();

            await _client.LoginAsync(Discord.TokenType.Bot, token);
            await _client.StartAsync();

            await Task.Delay(Timeout.Infinite);            
        }

        public async Task RegisterCommandAsync()
        {
            _client.MessageReceived += HandleCommandAsync;
            await _command.AddModulesAsync(Assembly.GetEntryAssembly(), _service);
        }

        private async Task HandleCommandAsync(SocketMessage arg)
        {
            var message = arg as SocketUserMessage;
            var context = new SocketCommandContext(_client, message);

            if (message == null || message.Author.IsBot) 
                return;

            int argPos = 0;
            if (message.HasStringPrefix("!", ref argPos))
            {
                var result = await _command.ExecuteAsync(context, argPos, _service);

                if (!result.IsSuccess) 
                    Console.WriteLine(result.ErrorReason);

                if (result.Error.Equals(CommandError.UnmetPrecondition)) 
                    await message.Channel.SendMessageAsync(result.ErrorReason);
            }
        }

        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }
    }
}
