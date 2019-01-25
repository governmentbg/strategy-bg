using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Models.Context
{
  [Table("Used_Files", Schema = "dbo")]
  public class Used_Files
  {
    public int ID { get; set; }

    public int RecordID { get; set; }

    public int FileID { get; set; }

    public byte TableType { get; set; }

  }


}