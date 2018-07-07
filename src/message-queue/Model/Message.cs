using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace message_queue.Model
{
    public class Message : INotifyPropertyChanged
    {
        public static string CarryModeratorIconURL;
        public static string CarrySubscriberIconURL;

        public string Text { get; set; }
        public string Name { get; set; }
        public string NameColor { get; set; }
        public int Count { get; set; }
        public bool Subscriber { get; set; }
        public bool Moderator { get; set; }
        public string ModeratorIconURL { get; set; }
        public string SubscriberIconURL { get; set; }

        public Message(string name, string text, bool subscriber, bool moderator)
        {
            Text = text;
            Name = name;
            Subscriber = subscriber;
            Moderator = moderator;
            ModeratorIconURL = CarryModeratorIconURL;
            SubscriberIconURL = CarrySubscriberIconURL;
        }

        private void ChangeProperty(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
