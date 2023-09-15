using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using threeLayer.Repository.Dtos;
using threeLayer.Service.Dtos;

namespace threeLayer.Service.Mapping
{
    public class ServiceMappings : Profile
    {
        public ServiceMappings()
        {
            // Info -> Condition
            this.CreateMap<CardInfo, CardCondition>();
            this.CreateMap<CardSearchInfo, CardSearchCondition>();

            // DataModel -> ResultModel
            this.CreateMap<CardDataModel, CardResultModel>();
        }
    }
}
