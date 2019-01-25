using System;
using System.Collections.Generic;
using System.Text;
using Nest;

namespace Elastic.Models.Data
{
    public class elasticContent
    {
        public string docId { get; set; }
        public double? Score { get; set; }
        public string Path { get; set; }
        public string Content { get; set; }
        public Attachment Attachment { get; set; }

    public elasticContent() { }

      public elasticContent(string _docID, string _Content, string _Path) {
      docId = _docID;
      Content = _Content;
      Path = _Path;
    }
  }
}
