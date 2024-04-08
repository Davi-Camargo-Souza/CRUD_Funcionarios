using CRUD_Funcionarios.Domain.Entities;
using CRUD_Funcionarios.Domain.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace CRUD_Funcionarios.WebAPI.Shared.Behavior
{
    public class FuncionarioEntityInterceptor : IFuncionarioEntityInterceptor
    {
        private readonly IValidatorFactory _validatorFactory;

        public FuncionarioEntityInterceptor(IValidatorFactory validatorFactory)
        {
            _validatorFactory = validatorFactory;
        }

        public void Validate(FuncionarioEntity funcionario)
        {
            if (funcionario == null)
            {
                throw new ArgumentNullException(nameof(funcionario));
            }

            var validator = _validatorFactory.GetValidator<FuncionarioEntity>();
            if (validator != null)
            {
                ValidationResult result = validator.Validate(funcionario);

                if (!result.IsValid)
                {
                    string errorMessage = string.Join(Environment.NewLine, result.Errors);
                    throw new ValidationException(errorMessage);
                }
            }
        }
    }
}
