using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Funcionarios.Domain.Exceptions
{
    public class CPFJaCadastradoException : Exception
    {
        public CPFJaCadastradoException() : base("CPF já cadastrado.") { }
        public CPFJaCadastradoException(string mensagem) : base(mensagem) { }
        public CPFJaCadastradoException(string mensagem, Exception innerException) : base(mensagem, innerException) { }
    }
}
