using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbiTrack.Components.Library.ViewModels
{
    public class LogResponseViewModel
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<LogViewModel> Result { get; set; }
    }
}
