using System;
using System.Collections.Generic;
using System.Text;

namespace Elastic.Models.Data
{
    public class elasticSettings
    {
        public string ClusterUrl { get; set; }
        public string DefaultIndex { get; set; }

        public elasticSettings() { }
    }

    public class SystemPaths
    {
      public const string News = "News/View?id=";
      public const string Publication = "Publication/View?id=";
      public const string StrategicDocument = "/StrategicDocument/View/";
      public const string PublicConsultation = "/PublicConsultation/View/";
      public const string PublicConsultationDoc = "/PublicConsultation/ViewDocument/";
      public const string Forums = "/Forums/";
      public const string Topics = "/Forums/Topic/";
      public const string CDN = "/FileCDN/DownloadFile/";
    /// <summary>
    /// //Когато няма наличен изходен обект            
    /// </summary>
    public const string Blank = "/";
    }
}
