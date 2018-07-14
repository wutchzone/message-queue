using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace message_queue.Model
{
    public class MySettings : Settings<MySettings>
    {
        public bool SubOnly = true;
        public string Name = "";
        public string Emote = "";
        public bool HideCounter = false;
    }
}
