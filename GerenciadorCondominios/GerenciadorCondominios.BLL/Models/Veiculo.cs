using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GerenciadorCondominios.BLL.Models
{
    public class Veiculo
    {
        public int VeiculoId { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(20, ErrorMessage = "Máximo de 20 caracteres")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(20, ErrorMessage = "Máximo de 20 caracteres")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(20, ErrorMessage = "Máximo de 20 caracteres")]
        public string Cor { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(7, ErrorMessage = "Máximo de 7 caracteres")]
        public string Placa { get; set; }

        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public DateTime Cadastro { get; set; }
    }
}
