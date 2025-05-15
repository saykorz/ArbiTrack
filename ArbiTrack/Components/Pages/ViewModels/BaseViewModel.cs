using ArbiTrack.Data.Interfaces;
using AutoMapper;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbiTrack.Components.Pages.ViewModels
{
    public  class BaseViewModel: ObservableObject
    {
        protected readonly IMapper _mapper;

        //protected readonly IRealtimeSyncService _sync;

        protected IUowData Data { get; set; }

        public BaseViewModel(IMapper mapper, IUowData data)//, IRealtimeSyncService sync
        {
            _mapper = mapper;
            //_sync = sync;
            Data = data;
        }
    }
}
