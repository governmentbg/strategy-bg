using Elastic.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Elastic.Models.Data;

namespace Elastic.Models.Contracts
{
    public interface ISearchService
    {
        Task<SearchResult<elasticContent>> Search(string query, int page, int pageSize);
        Task<SearchResult<elasticContent>> MoreLikeThis(string id, int page, int pageSize);


    }
}
