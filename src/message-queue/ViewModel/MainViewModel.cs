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
        private bool _hideCounter;
        private MySettings _mySettings;

        public string Name { get { return _name; } set { _name = value; ChangeProperty("Name"); } }
        public string Emote { get { return _emote; } set { _emote = value; ChangeProperty("Emote"); } }
        public bool SubOnly { get { return _subOnly; } set { _subOnly = value; ChangeProperty("SubOnly"); } }
        public bool EnableButton { get { return _enableleButton; } set { _enableleButton = value; ChangeProperty("EnableButton"); } }
        public bool HideCounter { get { return _hideCounter; } set { _hideCounter = value; ChangeProperty("HideCounter"); } }

        public Command CheckCommand { get; set; }
        public Command ClosingCommand { get; set; }

        public MainViewModel()
        {
            CheckCommand = new Command(Check);
            ClosingCommand = new Command(Closing);
            _mySettings = MySettings.Load();

            SubOnly = _mySettings.SubOnly;
            HideCounter = _mySettings.HideCounter;
            Name = _mySettings.Name;
            Emote = _mySettings.Emote;

            EnableButton = true;
        }

        public void Closing(object sender)
        {
            _mySettings.SubOnly = SubOnly;
            _mySettings.HideCounter = HideCounter;
            _mySettings.Name = Name;
            _mySettings.Emote = Emote;

            _mySettings.Save();
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
                (_queueWindow.DataContext as QueueViewModel).Emotes = _emotes;
                (_queueWindow.DataContext as QueueViewModel).Badges = _badges;

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
