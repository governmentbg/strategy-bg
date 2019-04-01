using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdServer.Models.Entities.Legacy
{
    [Table("v_old_users")]
    public class vOldUsers
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Organization { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Password { get; set; }
        public string Comment { get; set; }
        public bool IsApproved { get; set; }
    }
}
