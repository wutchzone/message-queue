using Base.ViewModel;
using message_queue.Model;
using System.Collections.Generic;
using message_queue.Assets;
using TwitchLib.Client.Events;
using System.Collections.ObjectModel;

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

        public List<Message> Messages { get { return _messages; } set { _messages = value; ChangeProperty("Messages"); } }
        public string Emote { get { return _emote; } set { _emote = value; ChangeProperty("Emote"); } }
        public TwitchResponseEmoticons Emotes { get { return _emotes; } set { _emotes = value; ChangeProperty("Emotes"); } }
        public TwitchResponseBadges Badges { get { return _badges; } set { _badges = value; ChangeProperty("Badges"); } }
        public string Channel { get { return _channel; } set { _channel = value; ChangeProperty("Channel"); } }

        public QueueViewModel()
        {
            Messages = new List<Message>();
        }

        public void OnMessage(object sender, OnMessageReceivedArgs e)
        {
            foreach (var item in e.ChatMessage.Message.Split(' '))
            {
                if (item.Contains(Emote))
                {

                    break;
                }
                else
                {
                    return;
                }
            }

            foreach (var item in Messages)
            {
                if(item.Name == e.ChatMessage.Username)
                {
                    item.Count++;
                    return;
                }
            }
            
            var _message = new Message(e.ChatMessage.Username, e.ChatMessage.Message, e.ChatMessage.IsSubscriber, e.ChatMessage.IsModerator);
            foreach (var item in Emotes.emoticons)
            {
                if(item.regex == Emote)
                {
                    _message.AddEmote(item.url);
                    break;
                }
            }
            
            _message.NameColor = e.ChatMessage.ColorHex;
            Messages.Add(_message);
            ChangeProperty("Messages");
        }

        public void Init()
        {
            _twitch = new Twitch(EnviromentVariables.BotName, EnviromentVariables.BotToken, Channel);
            _twitch.OnMessage = OnMessage;
        }

        public new void ChangeProperty(string propertyName) { base.ChangeProperty(propertyName); }
    }
}
