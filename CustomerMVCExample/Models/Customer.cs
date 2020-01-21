using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerMVCExample.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Column(TypeName ="nvarchar(50)")]
        public string FirstName { get; set; }
        [Column(TypeName ="nvarchar(50)")]
        public string LastName { get; set; }
        [Column(TypeName = "nvarchar(13)")]
        public string Cpf { get; set; }
        [Column(TypeName = "nvarchar(80)")]
        [Required]
        public string Email { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
