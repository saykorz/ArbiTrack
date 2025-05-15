using ArbiTrack.Data.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbiTrack.Components.Library.ViewModels
{
    public partial class ImpossibleFutureAppViewModel: EntityViewModel
    {
        public required string Address { get; set; }
        public required string Name { get; set; }
        public ObservableCollection<LogViewModel> Logs { get; set; } = new();

        public int Version { get; set; }

        [ObservableProperty]
        private int votes;

        [ObservableProperty]
        private int count;

        [ObservableProperty]
        private string isMajorityVoter;

        [ObservableProperty]
        private bool isBelowAverage;

        public ImpossibleFutureAppViewModel()
        {
            Logs.CollectionChanged += Logs_CollectionChanged;
        }

        private void Logs_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            // Ако има нови логове – закачи се за тях
            if (e.NewItems != null)
            {
                foreach (LogViewModel item in e.NewItems)
                {
                    item.PropertyChanged += Log_PropertyChanged;
                }
            }

            // Ако логове са махнати – откачи се
            if (e.OldItems != null)
            {
                foreach (LogViewModel item in e.OldItems)
                {
                    item.PropertyChanged -= Log_PropertyChanged;
                }
            }

            // Обнови Votes
            UpdateVotes();
        }

        private void Log_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(LogViewModel.Votes))
            {
                UpdateVotes();
            }
        }

        private void UpdateVotes()
        {
            Votes = Logs.Sum(x => x.Votes);
            Count = Logs?.Select(x => x.Voter).Distinct().Count() ?? 0;
            IsMajorityVoter = GetMajorityVoter();
        }

        public string GetMajorityVoter()
        {
            if (Logs == null || Logs.Count == 0)
                return string.Empty;

            int totalVotes = Logs.Sum(log => log.Votes);

            if (totalVotes == 0)
                return string.Empty;

            var voterGroups = Logs
                .GroupBy(log => log.Voter)
                .Select(group => new
                {
                    Voter = group.Key,
                    VoteCount = group.Sum(g => g.Votes)
                });

            var majority = voterGroups
                .FirstOrDefault(v => v.VoteCount > totalVotes / 2);

            return majority?.Voter;
        }

    }
}
