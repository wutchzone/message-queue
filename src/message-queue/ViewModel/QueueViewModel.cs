﻿using Base.ViewModel;
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

        public List<Message> Messages { get { return _messages; } set { _messages = value; ChangeProperty("Messages"); } }
        public string Emote { get { return _emote; } set { _emote = value; ChangeProperty("Emote"); } }
        public TwitchResponseEmoticons Emotes { get { return _emotes; } set { _emotes = value; ChangeProperty("Emotes"); } }
        public TwitchResponseBadges Badges { get { return _badges; } set { _badges = value; ChangeProperty("Badges"); } }
        public string Channel { get { return _channel; } set { _channel = value; ChangeProperty("Channel"); } }
        public bool SubOnly { get { return _subOnly; } set { _subOnly = value; ChangeProperty("SubOnly"); } }
        public int PageIndex { get { return _pageIndex; } set { _pageIndex = value; ChangeProperty("PageIndex"); } }

        public Command PageIndexCommand { get; set; }

        public QueueViewModel()
        {
            Messages = new List<Message>();
            PageIndexCommand = new Command(ChangePageIndex, ChangePagePredicate);

            PageIndex = 1;
        }

        public void OnMessage(object sender, OnMessageReceivedArgs e)
        {
            if(e.ChatMessage.IsBroadcaster == false || e.ChatMessage.IsModerator == false)
            {
                if (SubOnly == true && e.ChatMessage.IsSubscriber != true) return;
            }
            bool _shouldEnd = true;
            foreach (var item in e.ChatMessage.Message.Split(' '))
            {
                if (item.Contains(Emote))
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

        public void ChangePageIndex(object parameter)
        {
            PageIndex += int.Parse(parameter.ToString());
        }

        public bool ChangePagePredicate(object parameter)
        {
            return true;
        }

        public void Init()
        {
            _twitch = new Twitch(EnviromentVariables.BotName, EnviromentVariables.BotToken, Channel);
            _twitch.OnMessage = OnMessage;
        }

        public new void ChangeProperty(string propertyName) { base.ChangeProperty(propertyName); }
    }
}
