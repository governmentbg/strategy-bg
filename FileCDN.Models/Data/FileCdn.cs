using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FileCDN.Models.Data
{
    [Table("file_cdn", Schema = "itf")]
    public class FileCdn
    {
        public FileCdn()
        {
            this.FileContents = new HashSet<FileCdnContent>();
        }

        [Key]
        [Required]
        [MaxLength(50)]
        [Column("id")]
        public string Id { get; set; }

        [Required]
        [Column("source_type")]
        public int SourceType { get; set; }

        [Required]
        [Column("source_id")]
        public string SourceId { get; set; }

        [Required]
        [MaxLength(500)]
        [Column("file_name")]
        public string FileName { get; set; }

        [Column("file_title")]
        public string FileTitle { get; set; }

        [Column("file_description")]
        public string FileDescription { get; set; }

        [Column("content_type")]
        public string ContentType { get; set; }

        [Required]
        [Column("file_size")]
        public int FileSize { get; set; }

        [Required]
        [Column("date_uploaded")]
        public DateTime DateUploaded { get; set; }

        [MaxLength(500)]
        [Column("user_uploaded")]
        public string UserUploaded { get; set; }

        public DateTime? DateExparing { get; set; }
        public bool? IsReportVisible { get; set; }

        [Required]
        [Column("is_active")]
        public bool IsActive { get; set; }

        public virtual ICollection<FileCdnContent> FileContents { get; set; }
    }
}
