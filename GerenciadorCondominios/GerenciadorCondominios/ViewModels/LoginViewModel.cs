using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorCondominios.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        [StringLength(50)]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatótio")]
        [DataType(DataType.Password)]
        [StringLength(20)]
        public string Senha { get; set; }
    }
}
