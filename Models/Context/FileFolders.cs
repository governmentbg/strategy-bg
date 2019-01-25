using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Models.Context
{
  [Table("FileFolders", Schema = "dbo")]


  public class FileFolders
  {
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsActive { get; set; }

    public bool IsApproved { get; set; }

    public int CreatedByUserId { get; set; }

    public int ModifiedByUserId { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime DateModified { get; set; }

  }
}