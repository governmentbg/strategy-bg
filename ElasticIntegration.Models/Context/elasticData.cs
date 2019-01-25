using Nest;
using System;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Text;

namespace Elastic.Models.Data
{
    public class elasticData
    {
        public elasticData(IOptions<elasticSettings> settings)
        {
            ConnectionSettings connectionSettings =  new ConnectionSettings(new System.Uri(settings.Value.ClusterUrl));
            connectionSettings.EnableDebugMode();

            if (settings.Value.DefaultIndex != null)
            {
                connectionSettings.DefaultIndex(settings.Value.DefaultIndex);
            }
            this.Client = new ElasticClient(connectionSettings);

            var res = this.Client.ClusterHealth();

            string _ES_DefaultIndex = settings.Value.DefaultIndex;

            var indexResponse = this.Client.CreateIndex(_ES_DefaultIndex, c => c
              .Settings(s => s
                .Analysis(a => a
                  .Analyzers(ad => ad
                    .Custom("windows_path_hierarchy_analyzer", ca => ca
                      .Tokenizer("windows_path_hierarchy_tokenizer")
                    )
                  )
                  .Tokenizers(t => t
                    .PathHierarchy("windows_path_hierarchy_tokenizer", ph => ph
                      .Delimiter('\\')
                    )
                  )
                )
              )
              .Mappings(m => m
                .Map<elasticContent>(mp => mp
                  .AutoMap()
                  .AllField(all => all
                    .Enabled(false)
                  )
                  .Properties(ps => ps
                    .Text(s => s
                      .Name(n => n.Path)
                      .Analyzer("windows_path_hierarchy_analyzer")
                    )
                    .Object<Attachment>(a => a
                      .Name(n => n.Attachment)
                      .AutoMap()
                    )
                  )
                )
              )
            );

            var mappingResponse = this.Client.GetMapping<elasticContent>();

            this.Client.PutPipeline("attachments", p => p
              .Description("Document attachment pipeline")
              .Processors(pr => pr
                .Attachment<elasticContent>(a => a
                  .Field(f => f.Content)
                  .TargetField(f => f.Attachment)
                )
                .Remove<elasticContent>(r => r
                  .Field(f => f.Content)
                )
              )
            );
        }
   
        public ElasticClient Client { get; }
    }

}
