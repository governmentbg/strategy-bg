using System;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Hosting;
using Nest;
using Newtonsoft.Json;
using Elastic.Models.Data;
using Elastic.Models.Contracts;
using Elastic.Models.ViewModels;

namespace Elastic.Models.Services
{
    public class DataIndexerService: IDataIndexerService
    {
        private readonly ElasticClient client;
        private readonly string contentRootPath;
        private readonly string defaultIndex;

        public DataIndexerService(elasticData clientProvider, IHostingEnvironment env, IOptions<elasticSettings> settings)
        {
            this.client = clientProvider.Client;
            this.contentRootPath = Path.Combine(env.ContentRootPath, "data");
            this.defaultIndex = settings.Value.DefaultIndex;
        }

        public async Task<IndexResult> indexDocument(elasticContent Document)
        {
            return await _index(Document);
        }

        private async Task<IndexResult> _index(elasticContent Document)
        {
            var response = await this.client.IndexAsync(Document, i => i.Pipeline("attachments"));

            if (!response.IsValid)
            {
                return new IndexResult
                {
                    IsValid = false,
                    ErrorReason = response.ServerError?.Error?.Reason,
                    Exception = response.OriginalException
                };
            }
            else
            {
                Debug.WriteLine($"Successfully indexed!");
            }

            return new IndexResult
            {
                IsValid = true
            };
        }


        public async Task<IndexResult> IndexDocumentsFromArchiveFile(string fileName, bool deleteIndexIfExists, string index = null)
        {
            SanitizeIndexName(ref index);
            StgDocument[] mappedCollection = await ParseJsonFile(fileName);
            await DeleteIndexIfExists(index, deleteIndexIfExists);
            await CreateIndexIfItDoesntExist(index);
            await ConfigurePagination(index);
            return await IndexDocuments(mappedCollection, index);
        }

        private void SanitizeIndexName(ref string index)
        {
            // The index must be lowercase, this is a requirement from Elastic
            if (index == null)
            {
                index = this.defaultIndex;
            }
            else
            {
                index = index.ToLower();
            }
        }

        private async Task<IndexResult> IndexDocuments(StgDocument[] mappedCollection, string index)
        {
            int batchSize = 10000; // magic
            int totalBatches = (int)Math.Ceiling((double)mappedCollection.Length / batchSize);

            for (int i = 0; i < totalBatches; i++)
            {
                var response = await this.client.IndexManyAsync(mappedCollection.Skip(i * batchSize).Take(batchSize), index);

                if (!response.IsValid)
                {
                    return new IndexResult
                    {
                        IsValid = false,
                        ErrorReason = response.ServerError?.Error?.Reason,
                        Exception = response.OriginalException
                    };
                }
                else
                {
                    Debug.WriteLine($"Successfully indexed batch {i + 1}");
                }
            }

            return new IndexResult
            {
                IsValid = true
            };
        }

        private async Task ConfigurePagination(string index)
        {
            // Max out the result window so you can have pagination for >100 pages
            await this.client.UpdateIndexSettingsAsync(index, ixs => ixs
                 .IndexSettings(s => s
                     .Setting("max_result_window", int.MaxValue)));
        }

        private async Task CreateIndexIfItDoesntExist(string index)
        {
            if (!this.client.IndexExists(index).Exists)
            {
                var indexDescriptor = new CreateIndexDescriptor(index)
                                .Mappings(mappings => mappings
                                    .Map<StgDocument>(m => m.AutoMap()));

                await this.client.CreateIndexAsync(index, i => indexDescriptor);
            }
        }

        private async Task DeleteIndexIfExists(string index, bool shouldDeleteIndex)
        {
            if (this.client.IndexExists(index).Exists && shouldDeleteIndex)
            {
                await this.client.DeleteIndexAsync(index);
            }
        }

        private async Task<StgDocument[]> ParseJsonFile(string fileName)
        {
            using (FileStream fs = new FileStream(Path.Combine(contentRootPath, fileName), FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(fs))
                {
                    // Won't be efficient with large files
                    string rawJsonCollection = await reader.ReadToEndAsync();

                    StgDocument[] mappedCollection = JsonConvert.DeserializeObject<StgDocument[]>(rawJsonCollection, new JsonSerializerSettings
                    {
                        Error = HandleDeserializationError
                    });

                    return mappedCollection;
                }
            }
        }

        private void HandleDeserializationError(object sender, Newtonsoft.Json.Serialization.ErrorEventArgs errorArgs)
        {
            var currentError = errorArgs.ErrorContext.Error.Message;
            errorArgs.ErrorContext.Handled = true;
        }

        public string PathCreator(string _SystemPath, object _id)
        {
          string path = _SystemPath + _id.ToString();
          return path;
        }
  }
}

