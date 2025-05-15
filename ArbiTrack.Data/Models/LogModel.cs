using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbiTrack.Data.Models
{
    public class LogModel: EntityModel
    {
        public string Address { get; set; }
        public List<string> Topics { get; set; }
        public string Data { get; set; }
        public string BlockNumber { get; set; }
        public string BlockHash { get; set; }
        public string TimeStamp { get; set; }
        public string GasPrice { get; set; }
        public string GasUsed { get; set; }
        public string LogIndex { get; set; }
        public string TransactionHash { get; set; }
        public string TransactionIndex { get; set; }
    }
}
