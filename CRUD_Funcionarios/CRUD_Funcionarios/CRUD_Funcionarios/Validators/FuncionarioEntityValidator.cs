using CRUD_Funcionarios.Domain.Entities;
using FluentValidation;
namespace CRUD_Funcionarios.WebAPI.Validators
{
    public class FuncionarioEntityValidator : AbstractValidator<FuncionarioEntity>
    {
        public FuncionarioEntityValidator() 
        {
            RuleFor(x => x.CPF).NotEmpty().WithMessage("O preenchimento do CPF é obrigatório.");
            RuleFor(x => x.CPF).MinimumLength(11).WithMessage("O CPF precisa ter 11 caracteres.");
            RuleFor(x => x.CPF).MaximumLength(11).WithMessage("O CPF não pode ultrapassar 11 caracteres.");

            RuleFor(x => x.Email).NotEmpty().WithMessage("O preenchimento do email é obrigatório.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("O email precisa estar no formato correto.");

            RuleFor(x => x.Nome).NotEmpty().WithMessage("O nome não pode estar vazio.");
            RuleFor(x => x.Nome).MinimumLength(3).WithMessage("O nome precisa ter no mínimo 3 letras.");
            RuleFor(x => x.Nome).MaximumLength(20).WithMessage("O nome não pode ultrapassar 20 letras.");

            RuleFor(x => x.Sobrenome).NotEmpty().WithMessage("O sobrenome não pode estar vazio.");
            RuleFor(x => x.Sobrenome).MinimumLength(3).WithMessage("O sobrenome precisa ter no mínimo 3 letras.");
            RuleFor(x => x.Sobrenome).MaximumLength(25).WithMessage("O sobrenome não pode ultrapassar 25 letras.");
        }
    }
}
