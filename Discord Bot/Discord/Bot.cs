using System;
using System.Threading;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace szczepix.DiscordBot.Discord
{
    public class Bot
    {
        private static DiscordSocketClient _client;

//        public CancellationTokenSource cts = CancellationTokenSource.CreateLinkedTokenSource();
        private async Task MainAsync(CancellationToken ct)
        {
            _client = new DiscordSocketClient();

            _client.Log += Log;

//            botConfig = new BotConfig();

            string token = BotConfig.Token; // Remember to keep this private!
            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            // Block this task until the program is closed.
            await Task.Delay(-1);
        }

        private async Task MainAsync2()
        {
            _client = new DiscordSocketClient();

            _client.Log += Log;

            string token = BotConfig.Token; // Remember to keep this private!
            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            TextConsole.Log($"_client.Latency: {_client.Latency}");

            // Block this task until the program is closed.
            await Task.Delay(-1);
        }

        private Task Log(LogMessage msg)
        {
            TextConsole.Log(msg.ToString());
            return Task.CompletedTask;
        }

        public async void Start()
        {
            await MainAsync2();
        }

        public async void Start(CancellationToken ct)
        {
            try
            {
                // ***Send a token to carry the message if cancellation is requested.
                TextConsole.Log("Discord Bot starting...");
//                await MainAsync(cts.Token);
                TextConsole.Log("Discord Bot");
            }
            // *** If cancellation is requested, an OperationCanceledException results.
            catch (OperationCanceledException)
            {
                TextConsole.Log("Discord Bot stopped!");
            }
            catch (Exception e)
            {
                TextConsole.Log("Exception: " + e.Message);
            }
        }

        public async void Stop()
        {
            await _client.LogoutAsync();
            await _client.StopAsync();
            _client.Dispose();
            //            cts?.Cancel();
        }
    }
}
