using CustomerMVCExample.Models.Validations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerMVCExample.Models
{
    public class Customer
    {
        private DateTime _date = DateTime.Now;

        [Key]
        public int CustomerId { get; set; }
        [Column(TypeName ="nvarchar(50)")]
        [DisplayName("Nome")]
        public string FirstName { get; set; }
        [Column(TypeName ="nvarchar(50)")]
        [DisplayName("Sobrenome")]
        public string LastName { get; set; }
        [Column(TypeName = "nvarchar(13)")]
        [DisplayName("CPF")] 
        [CustomerValidation]
        public string Cpf { get; set; }
        [Column(TypeName = "nvarchar(80)")]
        [Required(ErrorMessage ="O e-mail é de preenchimento obrigatório.")]
        [DisplayName("E-mail")]
        [EmailAddress]
        public string Email { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        [DisplayName("Telefone")]
        public string PhoneNumber { get; set; }
        [HiddenInput(DisplayValue = false)]
        public DateTime CreatedAt { get { return _date; } set { _date = value; } }
        [HiddenInput(DisplayValue = false)]
        public DateTime UpdatedAt { get { return _date; } set { _date = value; } }
    }
}
