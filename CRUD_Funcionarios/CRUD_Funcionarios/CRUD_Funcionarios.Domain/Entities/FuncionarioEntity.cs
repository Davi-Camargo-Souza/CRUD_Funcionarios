using CRUD_Funcionarios.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Funcionarios.Domain.Entities
{
    public class FuncionarioEntity : BaseEntity
    {

        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public DepartamentoEnum Departamento { get; set; }
        public TurnoEnum Turno { get; set; }

    }
}
