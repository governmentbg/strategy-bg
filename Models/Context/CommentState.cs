using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.Context
{
    [Table("comments_states", Schema = "itf")]
    public class CommentState
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
