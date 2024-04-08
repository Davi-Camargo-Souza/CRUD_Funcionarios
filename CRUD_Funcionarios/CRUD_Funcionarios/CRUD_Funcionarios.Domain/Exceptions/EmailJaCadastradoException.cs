using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Funcionarios.Domain.Exceptions
{
    public class EmailJaCadastradoException : Exception
    {
        public EmailJaCadastradoException() : base("Email já cadastrado.") { }
        public EmailJaCadastradoException(string mensagem) : base(mensagem) { }
        public EmailJaCadastradoException(string mensagem, Exception innerException) : base(mensagem, innerException) { }
    }
}
