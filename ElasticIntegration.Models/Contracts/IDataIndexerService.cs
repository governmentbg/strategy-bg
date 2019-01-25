using Elastic.Models.Data;
using Elastic.Models.Services;
using Elastic.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Elastic.Models.Contracts
{
    public interface IDataIndexerService
    {
        Task<IndexResult> IndexDocumentsFromArchiveFile(string fileName, bool deleteIndexIfExists, string index = null);
        Task<IndexResult> indexDocument(elasticContent Document);
        string PathCreator(string _SystemPath, object _id);
    }
}
