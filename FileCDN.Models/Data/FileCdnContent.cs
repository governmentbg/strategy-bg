using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FileCDN.Models.Data
{
    [Table("file_cdn_content", Schema = "itf")]
    public class FileCdnContent
    {

        [Key]
        [Required]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("cdn_file_id")]
        public string CdnFileId { get; set; }

        [Required]
        [Column("content")]
        public byte[] Content { get; set; }

        [ForeignKey(nameof(CdnFileId))]
        public virtual FileCdn File { get; set; }
    }
}
