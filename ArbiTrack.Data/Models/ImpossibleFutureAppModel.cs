using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbiTrack.Data.Models
{
    public class ImpossibleFutureAppModel: EntityModel
    {
        public required string Address { get; set; }
        public required string Name { get; set; }
        public ICollection<LogModel>? Logs { get; set; }
        public int Version { get; set; }
    }
}
