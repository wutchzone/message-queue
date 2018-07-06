using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace message_queue.Model
{
    public class Message
    {
        static string ModeratorIconURL = "";
        static string SubscriberIconURL = "";

        public string Text { get; set; }
        public string Name { get; set; }
        public bool Subscriber { get; set; }
        public bool Moderator { get; set; }

        public Message(string name, string text, bool subscriber, bool moderator)
        {
            Text = text;
            Name = name;
            Subscriber = subscriber;
            Moderator = moderator;
        }
    }
}
