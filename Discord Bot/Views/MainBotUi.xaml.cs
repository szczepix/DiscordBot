using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using szczepix.DiscordBot.Discord;

namespace szczepix.DiscordBot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainBotUI : Window
    {
        public static Dispatcher MainDispatcher = Dispatcher.CurrentDispatcher;
        public static TextBlock ConsoleBlock;
        public static ScrollViewer ConsoleScrollViewer;

        public MainBotUI()
        {
            InitializeComponent();
            ButtonStop.IsEnabled = false;
            ConsoleBlock = TextBlockConsole;
            ConsoleScrollViewer = ScrollViewerConsole;
            TextConsole.Log("MainBotUi initialized");
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            TextConsole.Log("Button:  START clicked!");

            if(BotConfig.CheckTokenExist())
            {
                ButtonStart.IsEnabled = false;
                ButtonStop.IsEnabled = true;
                DiscordBot.Start();
            }
            else
            {
                TextConsole.Log("Please set Token before start Bot!");
            }

        }

        private void ButtonStop_Click(object sender, RoutedEventArgs e)
        {
            TextConsole.Log("Button:  STOP clicked!");
            ButtonStop.IsEnabled = false;
            ButtonStart.IsEnabled = true;
            DiscordBot.Stop();
        }

        private void ButtonTokenSave_Click(object sender, RoutedEventArgs e)
        {
            TabControlMain.SelectedIndex = 0;

            if (PasswordBoxToken.Password == "")
            {
                TextConsole.Log("First, fill in the Token field!");
                return;
            }

            BotConfig.SetToken(PasswordBoxToken.Password);

            ButtonTokenSave.IsEnabled = false;
        }
    }
}

