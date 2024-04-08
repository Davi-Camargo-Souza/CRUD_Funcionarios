using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Funcionarios.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime DataDeCriacao { get; set; } = DateTime.Now.ToUniversalTime();
        public DateTime DataDeAlteracao { get; set; } = DateTime.Now.ToUniversalTime();
        public bool Ativo { get; set; } = true;
    }
}
