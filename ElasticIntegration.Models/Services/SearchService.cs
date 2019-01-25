using System;
using System.Collections.Generic;
using System.Text;
using Elastic.Models.Data;
using Nest;
using System.Linq;
using System.Threading.Tasks;
using Elastic.Models.ViewModels;
using Elastic.Models.Contracts;

namespace Elastic.Models.Services
{
    public class SearchService: ISearchService
    {
        public SearchService(elasticData clientProvider)
        {
            this.client = clientProvider.Client;
        }

        private readonly ElasticClient client;

        /// <summary>
        /// Searches elastic for documents matching the given query. If a word in the query is preceeded by a '-' sign, the results won't contain it. Supports everything QueryStringQuery does,
        /// (wildcard queries, phrase matching, proximity matching, etc.) 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<SearchResult<elasticContent>> Search(string query, int page, int pageSize)
        {
            #region RawQuery
            /* 
            Passed query: "chopped onions" eggs -tomatoes -"olive oil"
            {
              "from": 0,
              "size": 10,
              "query": {
                "bool": {
                  "must": [
                    {
                      "query_string": {
                        "query": "\"chopped onions\" eggs -tomatoes -\"olive oil\""
                      }
                    }
                  ]
                }
              }
            }
            */
            #endregion

            var response = await this.client.SearchAsync<elasticContent>(searchDescriptor => searchDescriptor
                    .Query(queryContainerDescriptor => queryContainerDescriptor
                        .Bool(queryDescriptor => queryDescriptor
                            .Must(queryStringQuery => queryStringQuery
                                .QueryString(queryString => queryString
                                    .Query(query)))))
                                        .From((page - 1) * pageSize)
                                        .Size(pageSize));

            return MapResponseToSearchResult(response, page, pageSize);
        }

        public async Task<SearchResult<elasticContent>> MoreLikeThis(string id, int page, int pageSize)
        {
            #region RawQuery
            /*
            Raw query:
            {
              "from": (page - 1) * pageSize,
              "size": pageSize,
              "query": {
                "more_like_this": {
                  "fields": [
                    "ingredients"
                  ],
                  "like": [
                    {
                      "_index": "recipes",
                      "_type": "recipe",
                      "_id": "id"
                    }
                  ]
                }
              }
            }
            */
            #endregion

            var response = await this.client.SearchAsync<elasticContent>(s => s
                .Query(q => q
                    .MoreLikeThis(qd => qd
                        .Like(l => l.Document(d => d.Id(id)))
                        .Fields(fd => fd.Fields(r => r.Attachment.Content))))
                        .From((page - 1) * pageSize)
                        .Size(pageSize));

            return MapResponseToSearchResult(response, page, pageSize);
        }

        public async Task<elasticContent> GetById(string id)
        {
            var response = await this.client.GetAsync<elasticContent>(id);
            return response.Source;
        }

        public async Task<List<AutocompleteResult>> Autocomplete(string query)
        {
            #region RawQuery
            /*
            Raw query:
            {
              "suggest": {
                "recipe-name-completion": {
                  "prefix": "query",
                  "completion": {
                    "field": "name",
                    "fuzzy": {
                      "fuzziness": "AUTO"
                    }
                  }
                }
              }
            }
            */
            #endregion

            var suggestionResponse = await this.client.SearchAsync<elasticContent>(sr => sr
                .Suggest(scd => scd
                    .Completion("document-name-completion", cs => cs
                        .Prefix(query)
                        .Fuzzy(fsd => fsd
                            .Fuzziness(Fuzziness.Auto))
                        .Field(r => r.Attachment.Content))));

            List<AutocompleteResult> suggestions = this.ExtractAutocompleteSuggestions(suggestionResponse);

            return suggestions;
        }

        private List<AutocompleteResult> ExtractAutocompleteSuggestions(ISearchResponse<elasticContent> response)
        {
            List<AutocompleteResult> results = new List<AutocompleteResult>();

            var matchingOptions = response.Suggest["document-name-completion"].Select(s => s.Options);

            foreach (var option in matchingOptions)
            {
                results.AddRange(option.Select(opt => new AutocompleteResult() { Id = opt.Source.Attachment.Content, Name = opt.Source.Path }));
            }

            return results;
        }

        private SearchResult<elasticContent> MapResponseToSearchResult(ISearchResponse<elasticContent> response, int page, int pageSize)
        {

          List<elasticContent> _results = new List<elasticContent>();
          foreach (IHit<elasticContent> result in response.Hits)
          {
            _results.Add(new elasticContent
            {
              Score = result.Score,
              docId = result.Source.docId,
              Path = result.Source.Path,
              Attachment = result.Source.Attachment,
              Content = result.Source.Content
            });
          }

          return new SearchResult<elasticContent>
          {
              IsValid = response.IsValid,
              ErrorMessage = response.ApiCall.OriginalException?.Message,
              Total = response.Total,
              ElapsedMilliseconds = response.Took,
              Page = page,
              PageSize = pageSize,
              Results = _results
          };
         }
    }
}
