using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using FileCDN.Models.Data;

namespace Models.Context
{
    [Table("files_cdn_used", Schema = "itf")]
    public class FilesCDNUsed
    {
        [Key]
        [Display(Name = "id")]
        public int id { get; set; }

        [Display(Name = "cdn_file_id")]
        public string cdn_file_id { get; set; }

        [Display(Name = "source_type")]
        public int source_type { get; set; }

        [Display(Name = "source_id")]
        public int source_id { get; set; }

        [Display(Name = "order_by")]
        public int order_by { get; set; }

        [ForeignKey(nameof(cdn_file_id))]
        public virtual FileCdn FileCdn { get; set; }
    }
}
