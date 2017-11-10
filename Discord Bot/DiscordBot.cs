using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using szczepix.DiscordBot.Discord;

namespace szczepix.DiscordBot
{
    public class DiscordBot
    {
        private static Bot bot;

        public static void Start()
        {
            bot = new Bot();
            bot.Start();
        }

        public static void Stop()
        {
            bot?.Stop();
        }
    }
}