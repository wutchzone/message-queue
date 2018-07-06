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

        public List<Message> Messages { get { return _messages; } set { _messages = value; ChangeProperty("Messages"); } }
        public string Emote { get { return _emote; } set { _emote = value; ChangeProperty("Emote"); } }

        public QueueViewModel()
        {
            _messages = new List<Message>()
            {
               new Message("Wutchzone1", "Hey kappa", true, true),
               new Message("Wutchzone1", "Hey kappa", true, true),
               new Message("Wutchzone1", "Hey kappa", true, true)
            };
        }

        public new void ChangeProperty(string propertyName) { base.ChangeProperty(propertyName); }
    }
}
