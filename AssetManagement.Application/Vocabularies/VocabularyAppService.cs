using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using AssetManagement.Vocabularies.Dto;

namespace AssetManagement.Vocabularies
{
    public class VocabularyAppService : AssetManagementAppServiceBase, IVocabularyAppService
    {
        private readonly IRepository<Vocabulary, string> _vocabularyRepository;

        public VocabularyAppService(IRepository<Vocabulary, string> vocabularyRepository)
        {
            _vocabularyRepository = vocabularyRepository;
        }

        public async void CreateVocabulary(VocabularyInput input)
        {
            var vocabulary = new Vocabulary();
            vocabulary.Add(input.Code, input.Name);
            await _vocabularyRepository.InsertAsync(vocabulary).ConfigureAwait(false);
        }
    }
}