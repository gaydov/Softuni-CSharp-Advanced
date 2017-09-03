using System.Collections.Generic;

namespace LogsAggregator
{
    public class Session
    {
        public SortedSet<string> IPs { get; set; }

        public int Duration { get; set; }
    }
}