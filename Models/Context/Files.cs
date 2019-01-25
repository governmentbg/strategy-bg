using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Models.Context
{
  [Table("Files", Schema = "dbo")]
  public class Files
  {
    public int Id { get; set; }

    public int FolderId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Size { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsActive { get; set; }

    public bool IsApproved { get; set; }

    public int CreatedByUserId { get; set; }

    public int ModifiedByUserId { get; set; }

    public DateTime? DateExparing { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime DateModified { get; set; }

    public bool IsReportVisible { get; set; }

  }
}