using System;

namespace szczepix.DiscordBot
{
    public class TextConsole
    {
//        public static TextConsole Instance = new TextConsole();

        private TextConsole()
        {
        }

        public static void Log(string msg)
        {
            Add($"{DateTime.Now.Date} + {DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}     " + msg);
        }

        public static void Add(string msg)
        {
            MainBotUI.MainDispatcher.Invoke(() =>
            {
                MainBotUI.ConsoleBlock.Text += msg + "\n";
                MainBotUI.ConsoleScrollViewer.ScrollToBottom();
            });

            //TODO: Write all this string into "DiscordBot.log" file!!!
        }
    }
}