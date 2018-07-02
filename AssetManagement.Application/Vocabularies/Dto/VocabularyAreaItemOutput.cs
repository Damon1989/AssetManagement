using Abp.AutoMapper;

namespace AssetManagement.Vocabularies.Dto
{
    [AutoMapFrom(typeof(VocabularyItem))]
    public class VocabularyAreaItemOutput : VocabularyItemOutput
    {
        public bool IsActive { get; set; }
    }
}