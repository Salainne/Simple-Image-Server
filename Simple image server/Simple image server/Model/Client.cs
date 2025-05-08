using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_image_server.Model
{
    internal class Client
    {
        public string Id { get; set; }
        public DateTime LastRequest { get; set; }
        public DateTime LastNewImagetime { get; set; }

        public int LastServedImageId { get; set; }
        public string LastServedImageList { get; set; }
        public Queue<int> LastSeenIndices { get; set; }
        public int HistorySize { get { return 5; } }

        public Client()
        {
            LastNewImagetime = DateTime.Now;
            LastSeenIndices = new Queue<int>();
        }
    }
}
