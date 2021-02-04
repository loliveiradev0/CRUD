using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace todo.Models
{
    public class Atividades
    {   [Key]
        public int AtividadeId { get; set; }

        [DisplayName("Nome da atividade")]
        [Required(ErrorMessage = "O campo {0} é requerido")]
        public string Nome { get; set; }

        [DisplayName("Data para finalizar atividade")]
        [Required(ErrorMessage = "O campo {0} é requerido")]
        public DateTime Data { get; set; }


        public bool Concluída { get; set; }
        public bool Realizando { get; set; }
        public bool Fazer { get; set; }
    }
}