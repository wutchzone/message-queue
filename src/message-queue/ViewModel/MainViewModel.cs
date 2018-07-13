using Base.ViewModel;
using message_queue.Assets;
using message_queue.Model;
using message_queue.View;
using System.Windows;

namespace message_queue.ViewModel
{
    class MainViewModel : BaseViewModel
    {
        private string _name;
        private string _emote;
        private bool _subOnly;
        private bool _enableleButton;

        public string Name { get { return _name; } set { _name = value; ChangeProperty("Name"); } }
        public string Emote { get { return _emote; } set { _emote = value; ChangeProperty("Emote"); } }
        public bool SubOnly { get { return _subOnly; } set { _subOnly = value; ChangeProperty("SubOnly"); } }
        public bool EnableButton { get { return _enableleButton; } set { _enableleButton = value; ChangeProperty("EnableButton"); } }

        public Command CheckCommand { get; set; }

        public MainViewModel()
        {
            CheckCommand = new Command(Check);
            SubOnly = true;
            EnableButton = true;
        }

        public async void Check(object window)
        {
            EnableButton = false;

            var _window = window as MainWindow;

            if (await Twitch.ChechIfStreamExistsAsync(Name, EnviromentVariables.ClientID))
            {
                TwitchResponseEmoticons _emotes = await Twitch.GetEmotesForStreamAsync(Name, EnviromentVariables.ClientID);
                TwitchResponseBadges _badges = await Twitch.GetBadgesAsync(Name, EnviromentVariables.ClientID);

                Message.CarryModeratorIconURL = _badges.mod.image;
                Message.CarrySubscriberIconURL = _badges.subscriber?.image;

                

                _window.Hide();
                QueueWindow _queueWindow = new QueueWindow();
                (_queueWindow.DataContext as QueueViewModel).Emote = Emote;
                (_queueWindow.DataContext as QueueViewModel).Emotes = _emotes;
                (_queueWindow.DataContext as QueueViewModel).Badges = _badges;
                (_queueWindow.DataContext as QueueViewModel).Channel = Name;
                (_queueWindow.DataContext as QueueViewModel).Init();
                (_queueWindow.DataContext as QueueViewModel).SubOnly = SubOnly;

                _queueWindow.Show();
                _queueWindow.Closing += (sender, e) =>
                {
                    _window.Show();
                    _window.Close();
                };
            }
            else
            {
                MessageBox.Show("Streamer does not exist.");
                EnableButton = true;
            }

        }

        public new void ChangeProperty(string propertyName) { base.ChangeProperty(propertyName); }
    }
}
