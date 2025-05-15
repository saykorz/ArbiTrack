using ArbiTrack.Components.Library.Extensions;
using ArbiTrack.Data.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbiTrack.Components.Library.ViewModels
{
    public partial class LogViewModel: EntityViewModel
    {
        private string _timeStamp;

        [ObservableProperty]
        string address = string.Empty;

        [ObservableProperty]
        private List<string> topics;

        public string Data { get; set; }
        public string BlockNumber { get; set; }
        public string BlockHash { get; set; }
        public string TimeStamp
        {
            get => _timeStamp;
            set
            {
                _timeStamp = value;
                DateOn = _timeStamp.ToDateTimeFromHexTimestamp();
            }
        }
        public string GasPrice { get; set; }
        public string GasUsed { get; set; }
        public string LogIndex { get; set; }
        public string TransactionHash { get; set; }
        public string TransactionIndex { get; set; }

        [ObservableProperty]
        private string voter;

        [ObservableProperty]
        private string appId;

        [ObservableProperty]
        private int votes;

        [ObservableProperty]
        private DateTime dateOn;

        partial void OnTopicsChanged(List<string> value)
        {
            if (Topics != null)
            {
                Voter = Topics.Count > 1 ? Topics[1].ToEthereumAddress() : string.Empty;
                AppId = Topics.Count > 2 ? Topics[2].ToAppId() : string.Empty;
                Votes = Topics.Count > 3 ? Topics[3].ToVotes() : 0;
            }
            else
            {
                Voter = string.Empty;
                AppId = string.Empty;
                Votes = 0;
            }
        }
    }
}
