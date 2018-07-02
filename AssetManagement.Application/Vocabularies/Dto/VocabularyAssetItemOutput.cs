using Abp.AutoMapper;

namespace AssetManagement.Vocabularies.Dto
{
    [AutoMapFrom(typeof(VocabularyItem))]
    public class VocabularyAssetItemOutput : VocabularyItemOutput
    {
        public int Month { get; set; }
    }
}