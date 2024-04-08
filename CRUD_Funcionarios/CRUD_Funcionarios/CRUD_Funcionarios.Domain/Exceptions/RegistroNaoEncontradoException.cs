namespace CRUD_Funcionarios.Domain.Exceptions
{
    public class RegistroNaoEncontradoException : Exception
    {
        public RegistroNaoEncontradoException() : base("Registro não encontrado.") { }
        public RegistroNaoEncontradoException(string mensagem) : base(mensagem) { }
        public RegistroNaoEncontradoException(string mensagem, Exception innerException) : base(mensagem, innerException) { }
    }
}
