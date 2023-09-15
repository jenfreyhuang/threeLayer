using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace threeLayer.Service.Dtos
{
    // ProjectN.Service.Dtos.ResultModel
    public class CardResultModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Attack { get; set; }
        public int Health { get; set; }
        public int Cost { get; set; }
    }


    // ProjectN.Service.Dtos.Info
    public class CardInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Attack { get; set; }
        public int Health { get; set; }
        public int Cost { get; set; }
    }


    // ProjectN.Service.Dtos.Info
    public class CardSearchInfo
    {
        public string Name { get; set; }
        public int? MinAttack { get; set; }
        public int? MaxAttack { get; set; }
        public int? MinHealth { get; set; }
        public int? MaxHealth { get; set; }
        public int? MinCost { get; set; }
        public int? MaxCost { get; set; }
    }
}
