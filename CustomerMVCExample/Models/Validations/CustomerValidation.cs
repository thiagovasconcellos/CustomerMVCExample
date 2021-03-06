﻿using System;
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
           int[] firstValidation = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] secondValidation = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digit;
            int addLogic;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            tempCpf = cpf.Substring(0, 9);
            addLogic = 0;
            for (int i = 0; i < 9; i++)
                addLogic += int.Parse(tempCpf[i].ToString()) * firstValidation[i];
            resto = addLogic % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digit = resto.ToString();
            tempCpf = tempCpf + digit;
            addLogic = 0;
            for (int i = 0; i < 10; i++)
                addLogic += int.Parse(tempCpf[i].ToString()) * secondValidation[i];
            resto = addLogic % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digit = digit + resto.ToString();
            return cpf.EndsWith(digit);        
        }
    }
}
