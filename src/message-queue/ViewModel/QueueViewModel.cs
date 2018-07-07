using message_queue.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace message_queue.ViewModel
{
    class QueueViewModel : Base.ViewModel.BaseViewModel
    {
        private List<Message> _messages;
        private string _emote;
        private TwitchResponseEmoticons _emotes;
        private TwitchResponseBadges _badges;

        public List<Message> Messages { get { return _messages; } set { _messages = value; ChangeProperty("Messages"); } }
        public string Emote { get { return _emote; } set { _emote = value; ChangeProperty("Emote"); } }
        public TwitchResponseEmoticons Emotes { get { return _emotes; } set { _emotes = value; ChangeProperty("Emotes"); } }
        public TwitchResponseBadges Badges { get { return _badges; } set { _badges = value; ChangeProperty("Badges"); } }

        public QueueViewModel()
        {
            _messages = new List<Message>()
            {
               new Message("Wutchzone1", "Hey kappa", true, true),
               new Message("Wutchzone1", "Hey kappa", true, true),
               new Message("Wutchzone1", "Hey kappa", true, true),
               new Message("Wutchzone1", "Hey kappa", true, true),
               new Message("Wutchzone1", "Hey kappa5", true, true),
               new Message("Wutchzone1", "Hey kappa", true, true),
               new Message("Wutchzone1", "Hey kappa", true, true),
               new Message("Wutchzone1", "Hey kappa", true, true),
                new Message("Wutchzone1", "Hey kappa", true, true),
                new Message("Wutchzone1", "Hey kappa10", true, true),
               new Message("Wutchzone1", "Hey kappa", true, true),
               new Message("Wutchzone1", "Hey kappa", true, true),
               new Message("Wutchzone1", "Hey kappa", true, true),
               new Message("Wutchzone1", "Hey kappa", true, true),
               new Message("Wutchzone1", "Hey kappa15", true, true),
               new Message("Wutchzone1", "Hey kappa", true, true),
               new Message("Wutchzone1", "Hey kappa", true, true),
                new Message("Wutchzone1", "Hey kappa", true, true),
                new Message("Wutchzone1", "Hey kappa", true, true),
               new Message("Wutchzone1", "Hey kappa", true, true),
               new Message("Wutchzone1", "Hey kappa20", true, true),
               new Message("Wutchzone1", "Hey kappa", true, true),
               new Message("Wutchzone1", "Hey kappa", true, true),
               new Message("Wutchzone1", "Hey kappa", true, true),
               new Message("Wutchzone1", "Hey kappa", true, true),
               new Message("Wutchzone1", "Hey kappa25", true, true),
                new Message("Wutchzone1", "Hey kappa", true, true),
                new Message("Wutchzone1", "Hey kappa", true, true),
               new Message("Wutchzone1", "Hey kappa", true, true),
               new Message("Wutchzone1", "Hey kappa", true, true),
               new Message("Wutchzone1", "Hey kappa30", true, true),
               new Message("Wutchzone1", "Hey kappa", true, true),
               new Message("Wutchzone1", "Hey kappa", true, true),
               new Message("Wutchzone1", "Hey kappa", true, true),
               new Message("Wutchzone1", "Hey kappa", true, true),
                new Message("Wutchzone1", "Hey kappa35", true, true),
                new Message("Wutchzone1", "Hey kappa", true, true),
               new Message("Wutchzone1", "Hey kappa", true, true),
               new Message("Wutchzone1", "Hey kappa", true, true),
               new Message("Wutchzone1", "Hey kappa", true, true),
               new Message("Wutchzone1", "Hey kappa40", true, true),
               new Message("Wutchzone1", "Hey kappa", true, true),
               new Message("Wutchzone1", "Hey kappa", true, true),
               new Message("Wutchzone1", "Hey kappa", true, true),
                new Message("Wutchzone1", "Hey kappa", true, true),
                new Message("Wutchzone1", "Hey kappa45", true, true),
               new Message("Wutchzone1", "Hey kappa", true, true),
               new Message("Wutchzone1", "Hey kappa", true, true),
               new Message("Wutchzone1", "Hey kappa", true, true),
               new Message("Wutchzone1", "Hey kappa", true, true),
               new Message("Wutchzone1", "Hey kappa50", true, true),
               new Message("Wutchzone1", "Hey kappa", true, true),
               new Message("Wutchzone1", "Hey kappa", true, true),
                new Message("Wutchzone1", "Hey kappa", true, true)
            };
        }

        public new void ChangeProperty(string propertyName) { base.ChangeProperty(propertyName); }
    }
}
