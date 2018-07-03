using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AssetManagement.Vocabularies.Dto;

namespace AssetManagement.Vocabularies
{
    public interface IVocabularyAppService : IApplicationService
    {
        Task CreateVocabulary(VocabularyInput input);

        Task CreateAssetVocabulary(CreateVocabularyAssetItemInput input);

        Task UpdateAssetVocabulary(UpdateVocabularyAssetItemInput input);

        Task<ListResultDto<VocabularyAssetItemOutput>> GetAssetVocabularies();

        Task<ListResultDto<VocabularyAreaItemOutput>> GetAreaVocabularies();

        Task CreateAreaVocabulary(CreateVocabularyAreaItemInput input);

        Task UpdateAreaVocabulary(UpdateVocabularyAreaItemInput input);

        Task EnableVocabularyItem(VocabularyItemIdInput vocabularyItemIdInput);

        Task DisableVocabularyItem(VocabularyItemIdInput vocabularyItemIdInput);

        Task RemoveVocabularyItem(VocabularyItemIdInput vocabularyItemIdInput);
    }
}