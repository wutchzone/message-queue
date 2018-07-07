using Base.ViewModel;
using message_queue.Model;
using message_queue.View;
using message_queue.Assets;


namespace message_queue.ViewModel
{
    class MainViewModel : BaseViewModel
    {
        private string _name;
        private string _emote;

        public string Name { get { return _name; } set { _name = value; ChangeProperty("Name"); } }
        public string Emote { get { return _emote; } set { _emote = value; ChangeProperty("Emote"); } }

        public Command CheckCommand { get; set; }

        public MainViewModel()
        {
            CheckCommand = new Command(Check);
        }

        public async void Check(object window)
        {
            if(await Twitch.ChechIfStreamExistsAsync(Name, EnviromentVariables.ClientID))
            {
                TwitchResponseEmoticons _emotes = await Twitch.GetEmotesForStreamAsync(Name, EnviromentVariables.ClientID);
                TwitchResponseBadges _badges = await Twitch.GetBadgesAsync(Name, EnviromentVariables.ClientID);

                Message.CarryModeratorIconURL = _badges.mod.image;
                Message.CarrySubscriberIconURL = _badges?.subscriber.image;

                var _window = window as MainWindow;
                _window.Hide();
                QueueWindow _queueWindow = new QueueWindow();
                (_queueWindow.DataContext as QueueViewModel).Emote = Emote;
                (_queueWindow.DataContext as QueueViewModel).Emotes = _emotes;
                (_queueWindow.DataContext as QueueViewModel).Badges = _badges;
                _queueWindow.Show();
                _queueWindow.Closing += (sender, e) =>
                {
                    _window.Show();
                };
            }
            else
            {
                // TODO: Not exists
            }

        }

        public new void ChangeProperty(string propertyName) { base.ChangeProperty(propertyName); }
    }
}
