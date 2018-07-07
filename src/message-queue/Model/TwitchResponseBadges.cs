using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace message_queue.Model
{
    public class TwitchResponseBadges
    {
        public Badge global_mod { get; set; }
        public Badge admin { get; set; }
        public Badge broadcaster { get; set; }
        public Badge mod { get; set; }
        public Badge staff { get; set; }
        public Badge turbo { get; set; }
        public Badge subscriber { get; set; }
    }

    public class Badge
    {
        public string alpha { get; set; }
        public string image { get; set; }
        public string svg { get; set; }
    }
}
