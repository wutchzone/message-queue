using Base.ViewModel;
using message_queue.Assets;
using message_queue.Model;
using System.Collections.Generic;
using TwitchLib.Client.Events;

namespace message_queue.ViewModel
{
    class QueueViewModel : BaseViewModel
    {
        private List<Message> _messages;
        private string _emote;
        private TwitchResponseEmoticons _emotes;
        private TwitchResponseBadges _badges;
        private Twitch _twitch;
        private string _channel;
        private bool _subOnly;
        private int _pageIndex;
        private bool _hideCounter;
        private MySettings _mySettings;

        public List<Message> Messages { get { return _messages; } set { _messages = value; ChangeProperty("Messages"); } }
        public TwitchResponseEmoticons Emotes { get { return _emotes; } set { _emotes = value; ChangeProperty("Emotes"); } }
        public TwitchResponseBadges Badges { get { return _badges; } set { _badges = value; ChangeProperty("Badges"); } }
        public int PageIndex { get { return _pageIndex; } set { _pageIndex = value; ChangeProperty("PageIndex"); } }

        public int NumberOfElements { get; set; }

        public Command PageIndexCommand { get; set; }

        public QueueViewModel()
        {
            Messages = new List<Message>();
            PageIndexCommand = new Command(ChangePageIndex, ChangePagePredicate);

            _mySettings = MySettings.Load();
            _channel = _mySettings.Name;
            _emote = _mySettings.Emote;
            _hideCounter = _mySettings.HideCounter;
            Message.CarryHideCounter = _hideCounter;

            _twitch = new Twitch(EnviromentVariables.BotName, EnviromentVariables.BotToken, _channel);
            _twitch.OnMessage = OnMessage;

            PageIndex = 1;
        }

        public void OnMessage(object sender, OnMessageReceivedArgs e)
        {
            if (e.ChatMessage.IsBroadcaster == false || e.ChatMessage.IsModerator == false)
            {
                if (_subOnly == true && e.ChatMessage.IsSubscriber != true) return;
            }
            bool _shouldEnd = true;
            foreach (var item in e.ChatMessage.Message.Split(' '))
            {
                if (item.Contains(_emote))
                {
                    _shouldEnd = false;
                }
            }
            if (_shouldEnd)
            {
                return;
            }

            foreach (var item in Messages)
            {
                if (item.Name == e.ChatMessage.Username)
                {
                    item.Count++;
                    return;
                }
            }

            var _message = new Message(e.ChatMessage.Username, e.ChatMessage.Message, e.ChatMessage.IsSubscriber, e.ChatMessage.IsModerator);
            foreach (var item in Emotes.emoticons)
            {
                if (item.regex == _emote)
                {
                    _message.AddEmote(item.url);
                    break;
                }
            }

            _message.NameColor = e.ChatMessage.ColorHex;
            Messages.Add(_message);
            ChangeProperty("Messages");
        }

        public void ChangePageIndex(object parameter)
        {
            PageIndex += int.Parse(parameter.ToString());
        }

        public bool ChangePagePredicate(object parameter)
        {
            int _upOrDown = int.Parse(parameter.ToString());

            if (_upOrDown == 1)
            {
                if ((PageIndex * NumberOfElements) > Messages.Count) return false;

            }
            else if (_upOrDown == -1)
            {
                if (PageIndex == 1) return false;
            }

            return true;
        }

        public new void ChangeProperty(string propertyName) { base.ChangeProperty(propertyName); }
    }
}
