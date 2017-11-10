using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szczepix.DiscordBot.Discord
{
    internal static class BotConfig
    {
        private static string _token = string.Empty;

        public static string Token => _token;

        public static string CommandPrefix { get; set; } = string.Empty;

        public static void SetToken(string token)
        {
            //TODO: change token is possible only if bot not working
            _token = token;
            TextConsole.Log("Token has been successfully set.");
        }

        public static bool CheckTokenExist()
        {
            return _token != string.Empty;
        }
    }
}
