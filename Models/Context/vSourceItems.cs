using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.Context
{
    [Table("v_source_items",Schema ="itf")]
    public class vSourceItems
    {
        [Column("source_type")]
        public int SourceType { get; set; }

        [Column("source_id")]
        public int SourceId { get; set; }

        [Column("title")]
        public string Title { get; set; }
    }
}
