using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using AssetManagement.Vocabularies.Dto;
using Newtonsoft.Json;

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

        private async Task<Vocabulary> GetVocabulary(string code)
        {
            var vocabulary = await _vocabularyRepository.FirstOrDefaultAsync(v => v.Code == code).ConfigureAwait(false);
            if (vocabulary == null)
            {
                throw new UserFriendlyException($"父级编号{code}不存在");
            }

            return vocabulary;
        }

        private async Task CheckCreateVocabularyItem(string code, string vocabularyId)
        {
            if ((await _vocabularyItemRepository
                    .CountAsync(v => v.Code == code && v.VocabularyId == vocabularyId)
                    .ConfigureAwait(false)) > 0)
            {
                throw new UserFriendlyException($"编号{code}必须唯一");
            }
        }

        private async Task CheckUpdateVocabularyItem(string id, string code, string vocabularyId)
        {
            if ((await _vocabularyItemRepository
                    .CountAsync(v => v.Code == code
                                     && v.VocabularyId == vocabularyId
                                     && v.Id != id)
                    .ConfigureAwait(false)) > 0)
            {
                throw new UserFriendlyException($"编号{code}必须唯一");
            }
        }

        public async Task CreateAssetVocabulary(CreateVocabularyAssetItemInput input)
        {
            await CreateVocabularyItem(input, VocabularyConst.AssetCategory).ConfigureAwait(false);
        }

        public async Task UpdateAssetVocabulary(UpdateVocabularyAssetItemInput input)
        {
            await UpdateVocabularyItem(input, VocabularyConst.AssetCategory);
        }

        public async Task<ListResultDto<VocabularyAssetItemOutput>> GetAssetVocabularies()
        {
            var vocabularyItems = await GetVocabularyItems(VocabularyConst.AssetCategory)
                .ConfigureAwait(false);
            var result = await Task.FromResult(new ListResultDto<VocabularyAssetItemOutput>(
                ObjectMapper.Map<List<VocabularyAssetItemOutput>>(vocabularyItems)
            )).ConfigureAwait(false);

            foreach (var item in result.Items)
            {
                var extensionData = vocabularyItems.FirstOrDefault(c => c.Id == item.Id)?.ExtensionData;
                item.Month = JsonConvert.DeserializeObject<CreateVocabularyAssetItemInput>(extensionData).Month;
            }

            return result;
        }

        public async Task<ListResultDto<VocabularyAreaItemOutput>> GetAreaVocabularies()
        {
            var vocabularyItems = await GetVocabularyItems(VocabularyConst.AreaCategory)
                .ConfigureAwait(false);
            var result = await Task.FromResult(new ListResultDto<VocabularyAreaItemOutput>(
                ObjectMapper.Map<List<VocabularyAreaItemOutput>>(vocabularyItems)
            )).ConfigureAwait(false);

            return result;
        }

        public async Task CreateAreaVocabulary(CreateVocabularyAreaItemInput input)
        {
            await CreateVocabularyItem(input, VocabularyConst.AreaCategory).ConfigureAwait(false);
        }

        public async Task UpdateAreaVocabulary(UpdateVocabularyAreaItemInput input)
        {
            await UpdateVocabularyItem(input, VocabularyConst.AreaCategory).ConfigureAwait(false);
        }

        private async Task CreateVocabularyItem(CreateVocabularyItemInput input, string category)
        {
            var vocabulary = await GetVocabulary(category).ConfigureAwait(false);

            await CheckCreateVocabularyItem(input.Code, vocabulary.Id).ConfigureAwait(false);

            var item = new VocabularyItem(input, vocabulary.Id);
            item.Add(input.Code, input.Name);
            await _vocabularyItemRepository.InsertAsync(item).ConfigureAwait(false);
        }

        private async Task UpdateVocabularyItem(UpdateVocabularyItemInput input, string category)
        {
            var vocabulary = await GetVocabulary(category).ConfigureAwait(false);

            await CheckUpdateVocabularyItem(input.Id, input.Code, vocabulary.Id).ConfigureAwait(false);

            var item = await _vocabularyItemRepository.FirstOrDefaultAsync(v => v.Id == input.Id).ConfigureAwait(false);
            item.Update(input.Code, input.Name, input);
            await _vocabularyItemRepository.UpdateAsync(item).ConfigureAwait(false);
        }

        private async Task<List<VocabularyItem>> GetVocabularyItems(string category)
        {
            var vocabulary = await GetVocabulary(category).ConfigureAwait(false);

            var vocabularyItems = await _vocabularyItemRepository.GetAllListAsync(c => c.VocabularyId == vocabulary.Id)
                .ConfigureAwait(false);

            return vocabularyItems;
        }
    }
}