using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace message_queue.Model
{
    public class TwitchResponseEmoticons
    {
        public Emote[] emoticons { get; set; }
    }

    public class Emote
    {
        public string regex { get; set; }
        public string state { get; set; }
        public bool subscriber_only { get; set; }
        public string url { get; set; }
        public int height { get; set; }
        public int width { get; set; }
    }
}
