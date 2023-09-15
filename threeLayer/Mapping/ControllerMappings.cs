using AutoMapper;
using threeLayer.Parameter;
using threeLayer.Service.Dtos;

namespace threeLayer.Mapping
{
    public class ControllerMappings : Profile
    {
        public ControllerMappings()
        {
            // Parameter -> Info
            this.CreateMap<CardParameter, CardInfo>();
            this.CreateMap<CardSearchParameter, CardSearchInfo>();

            // ResultModel -> ViewModel
            this.CreateMap<CardResultModel, CardViewModel>();
        }
    }
}
