using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using threeLayer.Repository.Dtos;
using threeLayer.Repository.Implement;
using threeLayer.Repository.Interface;
using threeLayer.Service.Dtos;
using threeLayer.Service.Interface;
using threeLayer.Service.Mapping;

namespace threeLayer.Service.Implement
{
    
        /// <summary>
        /// 卡片管理
        /// </summary>
        /// <seealso cref="ProjectN.Service.Interface.ICardService" />
        public class CardService : ICardService
        {
            private readonly IMapper _mapper;
            private readonly ICardRepository _cardRepository;

            /// <summary>
            /// 建構式
            /// </summary>
            public CardService(ICardRepository cardRepository)
            {
                //this._cardRepository = new CardRepository();
                this._cardRepository = cardRepository;

            var config = new MapperConfiguration(cfg =>
                    cfg.AddProfile<ServiceMappings>());

                this._mapper = config.CreateMapper();
            }

            /// <summary>
            /// 查詢卡片列表
            /// </summary>
            /// <param name="info"></param>
            /// <returns></returns>
            public IEnumerable<CardResultModel> GetList(CardSearchInfo info)
            {
                var condition = this._mapper.Map<CardSearchInfo, CardSearchCondition>(info);
                var cards = this._cardRepository.GetList(condition);

                var result = this._mapper.Map<
                    IEnumerable<CardDataModel>,
                    IEnumerable<CardResultModel>>(cards);

                return result;
            }

            /// <summary>
            /// 查詢卡片
            /// </summary>
            /// <param name="id">卡片編號</param>
            /// <returns></returns>
            public CardResultModel Get(int id)
            {
                var card = this._cardRepository.Get(id);
                var result = this._mapper.Map<CardDataModel, CardResultModel>(card);

                return result;
            }

            /// <summary>
            /// 新增卡片
            /// </summary>
            /// <param name="info"></param>
            /// <returns></returns>
            public bool Insert(CardInfo info)
            {
                var condition = this._mapper.Map<CardInfo, CardCondition>(info);
                var result = this._cardRepository.Insert(condition);
                return result;
            }

            /// <summary>
            /// 更新卡片
            /// </summary>
            /// <param name="id">卡片編號</param>
            /// <param name="info"></param>
            /// <returns></returns>
            public bool Update(int id, CardInfo info)
            {
                var condition = this._mapper.Map<CardInfo, CardCondition>(info);
                var result = this._cardRepository.Update(id, condition);
                return result;
            }

            /// <summary>
            /// 刪除卡片
            /// </summary>
            /// <param name="id">卡片編號</param>
            /// <returns></returns>
            public bool Delete(int id)
            {
                var result = this._cardRepository.Delete(id);
                return result;
            }
        }
    }

