namespace Hipica.Backend.Models.Authentication
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserSession
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OwnerUserId { get; set; }

        public virtual ApplicationUser OwnerUser { get; set; }

        [Required]
        [MaxLength(1024)]
        public string AuthToken { get; set; }

        [Required]
        public DateTime ExpirationDateTime { get; set; }
    }
}