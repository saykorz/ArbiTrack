using ArbiTrack.Components.Library.ViewModels;
using ArbiTrack.Data.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbiTrack.Components.Library.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ImpossibleFutureAppModel, ImpossibleFutureAppViewModel>()
                .ForMember(x => x.IsMajorityVoter, c => c.Ignore())
                .ForMember(x => x.IsBelowAverage, c => c.Ignore())
                .ForMember(x => x.Votes, c => c.Ignore())
                .ForMember(x => x.Count, c => c.Ignore())
                .ForMember(dest => dest.Logs, opt => opt.Ignore());

            CreateMap<LogModel, LogViewModel>()
                .ForMember(x => x.DateOn, c => c.Ignore())
                .ForMember(x => x.Voter, c => c.Ignore())
                .ForMember(x => x.AppId, c => c.Ignore())
                .ForMember(x => x.Votes, c => c.Ignore());

            //CreateMap<LogViewModel, LogModel>().ForMember(dest => dest.Topics, opt => opt.MapFrom(src => string.Join(",", src.Topics)))
            //.ForMember(dest => dest.TimeStamp, opt => opt.MapFrom(src => Convert.ToInt64(src.TimeStamp, 16)))
            //.ForMember(dest => dest.BlockNumber, opt => opt.MapFrom(src => Convert.ToInt64(src.BlockNumber, 16)))
            //.ForMember(dest => dest.GasUsed, opt => opt.MapFrom(src => Convert.ToInt64(src.GasUsed, 16)))
            //.ForMember(dest => dest.GasPrice, opt => opt.MapFrom(src => Convert.ToInt64(src.GasPrice, 16)));
        }

        private int SafeParseId(string id) => int.TryParse(id, out var result) ? result : 0;

        private int? SafeParseNullableId(string id) => int.TryParse(id, out var result) ? result : null;

    }
}
