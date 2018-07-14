using System.Collections.Generic;
using System.ComponentModel;

namespace message_queue.Model
{
    public class Message : INotifyPropertyChanged
    {
        private string _nameColor;
        private int _count;
        private bool _subscriber;
        private bool _moderator;
        private List<string> _emotesURL;

        public static string CarryModeratorIconURL;
        public static string CarrySubscriberIconURL;
        public static bool CarryHideCounter;

        public string Text { get; set; }
        public List<string> EmotesURL { get { return _emotesURL; } private set { _emotesURL = value; ChangeProperty("EmotesURL"); } }
        public string Name { get; set; }
        public string NameColor { get { return _nameColor; } set { _nameColor = value; ChangeProperty("NameColor"); } }
        public int Count { get { return _count; } set { _count = value; ChangeProperty("Count"); } }
        public bool Subscriber { get { return _subscriber; } set { _subscriber = value; ChangeProperty("Subscriber"); } }
        public bool Moderator { get { return _moderator; } set { _moderator = value; ChangeProperty("Moderator"); } }
        public string ModeratorIconURL { get; set; }
        public string SubscriberIconURL { get; set; }
        public bool HideCounter { get; set; }

        public Message(string name, string text, bool subscriber, bool moderator)
        {
            Text = text;
            Name = name;
            Subscriber = subscriber;
            Moderator = moderator;
            ModeratorIconURL = CarryModeratorIconURL;
            SubscriberIconURL = CarrySubscriberIconURL;
            HideCounter = CarryHideCounter;
            Count = 1;
            NameColor = "#f00";
            EmotesURL = new List<string>();
        }

        public void AddEmote(string URL)
        {
            EmotesURL.Add(URL);
            ChangeProperty("EmotesURL");
        }

        private void ChangeProperty(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
