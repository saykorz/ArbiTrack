using ArbiTrack.Components.Library.Extensions;
using ArbiTrack.Components.Library.ViewModels;
using ArbiTrack.Data.Interfaces;
using ArbiTrack.Data.Models;
using AutoMapper;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Model = ArbiTrack.Data.Models.ImpossibleFutureAppModel;
using ViewModel = ArbiTrack.Components.Library.ViewModels.ImpossibleFutureAppViewModel;

namespace ArbiTrack.Components.Pages.ViewModels
{
    public partial class HomeViewModel : GenericBaseViewModel<Model, ViewModel>
    {
        [ObservableProperty]
        public bool isDialogOpen = false;

        [ObservableProperty]
        public int uniqueVoters = 0;

        [ObservableProperty]
        public partial string SelectedAddress { get; set; } = string.Empty;

        public ObservableCollection<LogViewModel> logsForVoter { get; set; } = new ObservableCollection<LogViewModel>();

        public HomeViewModel(IMapper mapper, IUowData data)
            : base(mapper, data, data.ImpossibleFutureApps)
        {
        }

        public async Task FetchLogsAsync()
        {
            await AppCache.BusyIndicator.RunAsync(async () =>
            {
                Items.ForEach(x => { x.Logs.Clear(); });

                var url = "https://api.arbiscan.io/api?module=logs&action=getLogs&address=0xDDF628DF36bA857c9b5a3453C9105167e2519Cbf&page=1&offset=1000&apikey=5DE7853WBAECBPJVQCGX32PVJXC7K8FPM9";

                using var httpClient = new HttpClient();
                var response = await httpClient.GetStringAsync(url);

                var logsResponse = JsonSerializer.Deserialize<LogResponseViewModel>(response, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (logsResponse?.Status == "1")
                {
                    var groupedByVoter = logsResponse.Result
                        .GroupBy(log => log.AppId)
                        .ToDictionary(group => group.Key, group => group.ToList());
                    
                    foreach (var kvp in groupedByVoter)
                    {
                        var app = Items.FirstOrDefault(x => x.Address == kvp.Key);
                        if (app != null)
                        {
                            app.Logs.AddRange(kvp.Value);
                        }
                    }
                }

                Items = Items.OrderByDescending(x => x.Count).ThenByDescending(x => x.Votes).ToObservableCollection();
                var averateVotes = Items.Sum(x => x.Count) / Items.Count();
                Items.ForEach(i => i.IsBelowAverage = i.Count < averateVotes);
                uniqueVoters = Items.SelectMany(item => item.Logs)
                        .Select(log => log.Voter)
                        .Where(voter => !string.IsNullOrWhiteSpace(voter))
                        .Distinct().Count();
            }, "Fetch Logs");
        }

        public void OnVoterClicked(string voterAddress)
        {
            SelectedAddress = voterAddress;
            logsForVoter = GetLogsByVoter(voterAddress);
            IsDialogOpen = true;
        }

        public ObservableCollection<LogViewModel> GetLogsByVoter(string voterAddress)
        {
            var result = new ObservableCollection<LogViewModel>();

            // Преглеждаме всички Items и техните Logs
            foreach (var item in Items)
            {
                var logsForVoter = item.Logs.Where(log => log.Voter == voterAddress).ToList();

                // Добавяме тези логове към резултатите
                foreach (var log in logsForVoter)
                {
                    // Търсим името на приложението по AppId
                    var app = Items.FirstOrDefault(i => i.Address == log.AppId);

                    // Ако намерим приложението, добавяме името му в log-а
                    if (app != null)
                    {
                        log.Address = app.Name; // Предполагам, че имаш свойство "Name" за името на приложението
                    }

                    result.Add(log);
                }
            }

            return result;
        }


        protected override Task<bool> DeleteData(ViewModel model)
        {
            throw new NotImplementedException();
        }

        internal override Task<Model> CreateOrUpdateData(ViewModel model, string id)
        {
            throw new NotImplementedException();
        }
    }
}
