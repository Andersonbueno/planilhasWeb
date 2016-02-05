﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Planilhas.Models
{
    public class UserAccount
    {
        [Key]
        public int ColaboradorId { get; set; }

        [Required(ErrorMessage ="Digite seu nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite seu sobrenome")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Digite seu email")]
        [RegularExpression("^[A-Za-z0-9](([_.-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([.-]?[a-zA-Z0-9]+)*)([.][A-Za-z]{2,4})$", ErrorMessage = "Informe um email válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite seu departamento")]
        [Display(Name = "Depart.")]
        public string Departamentos { get; set; }

        [Required(ErrorMessage = "Usuario precisa ser preenchido.")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Senha precisa ser preenchida.")]
        [DataType(DataType.Password)]
        public string Senha  { get; set; }

        [Compare("Senha", ErrorMessage = "Por favor confirme sua senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string ConfirmeSenha { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }

    public class Role
    {
        [Key]
        public short RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
    }

    public class UserRole
    {
        [Key]
        public int UserRoleId { get; set; }
        public int UserId { get; set; }
        public short RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}