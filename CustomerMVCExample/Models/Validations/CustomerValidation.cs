using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerMVCExample.Models.Validations
{
    public class CustomerValidation : ValidationAttribute
    {
        public CustomerValidation()
        {
        
        }

        public string Cpf { get; set; }

        public string GetErrorMessage() =>
            $"O cpf {Cpf} informado é inválido";
        public string GetLenghtErrorMessage() =>
            $"O cpf {Cpf} informado não possuí a quantidade mínima de caracteres!";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            Cpf = customer.Cpf;            
            
            if (Cpf.Length != 11)
                return new ValidationResult(GetLenghtErrorMessage());
           
            if (!IsValidCpf(Cpf))
            {
                return new ValidationResult(GetErrorMessage());
            }
            
            return base.IsValid(value, validationContext);
        }

        public bool IsValidCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            tempCpf = cpf.Substring(0, 9);
            soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);                        
        }
    }
}
