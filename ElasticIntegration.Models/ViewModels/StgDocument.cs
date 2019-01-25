using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elastic.Models.ViewModels
{
    [ElasticsearchType(Name = "document")]
    public class StgDocument
    {
        public string Id { get; set; }

        [Completion]
        public string Title { get; set; }
        [Text]
        public string Content { get; set; }

        public string Path { get; set; }

        public DateTime? DatePublished { get; set; }

        public string Description { get; set; }
    }
}
