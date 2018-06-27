using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using AssetManagement.Vocabularies.Dto;

namespace AssetManagement.Vocabularies
{
    public interface IVocabularyAppService : IApplicationService
    {
        Task CreateVocabulary(VocabularyInput input);

        Task CreateAssetVocabulary(VocabularyAssetItemInput input);
    }
}