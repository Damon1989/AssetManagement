using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.UI;
using AssetManagement.Vocabularies.Dto;

namespace AssetManagement.Vocabularies
{
    public class VocabularyAppService : AssetManagementAppServiceBase, IVocabularyAppService
    {
        private readonly IRepository<Vocabulary, string> _vocabularyRepository;
        private readonly IRepository<VocabularyItem, string> _vocabularyItemRepository;

        public VocabularyAppService(IRepository<Vocabulary, string> vocabularyRepository,
            IRepository<VocabularyItem, string> vocabularyItemRepository)
        {
            _vocabularyRepository = vocabularyRepository;
            _vocabularyItemRepository = vocabularyItemRepository;
        }

        public async Task CreateVocabulary(VocabularyInput input)
        {
            if ((await _vocabularyRepository.CountAsync(v => v.Code == input.Code).ConfigureAwait(false)) > 0)
            {
                throw new UserFriendlyException($"编号{input.Code}必须唯一");
            }
            var vocabulary = new Vocabulary();
            vocabulary.Add(input.Code, input.Name);
            await _vocabularyRepository.InsertAsync(vocabulary).ConfigureAwait(false);
        }

        public async Task CreateAssetVocabulary(VocabularyAssetItemInput input)
        {
            if ((await _vocabularyItemRepository
                    .CountAsync(v => v.Code == input.Code && v.VocabularyId == VocabularyConst.AssetCategoryId)
                    .ConfigureAwait(false)) > 0)
            {
                throw new UserFriendlyException($"编号{input.Code}必须唯一");
            }
            var item = new VocabularyItem(input, VocabularyConst.AssetCategoryId);
            item.Add(input.Code, input.Name);
            await _vocabularyItemRepository.InsertAsync(item).ConfigureAwait(false);
        }
    }
}