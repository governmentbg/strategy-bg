using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdServer.Models.Entities
{
    [Table("claims")]
    public class Claim
    {
        [Key]
        [MaxLength(50)]
        [Column("id")]
        public string Id { get; set; }

        [MaxLength(50)]
        [Required]
        [Column("user_id")]
        public string UserId { get; set; }

        [MaxLength(50)]
        [Column("client_id")]
        public string ClientId { get; set; }

        [Required]
        [MaxLength(250)]
        [Column("claim_type")]
        public string ClaimType { get; set; }

        [Required]
        [MaxLength(250)]
        [Column("claim_value")]
        public string ClaimValue { get; set; }

        public Claim(string claimType, string claimValue)
        {
            ClaimType = claimType;
            ClaimValue = claimValue;
        }

        public Claim(string claimType, string claimValue, string clientId)
        {
            ClaimType = claimType;
            ClaimValue = claimValue;
            ClientId = clientId;
        }

        public Claim()
        {

        }
    }
}
