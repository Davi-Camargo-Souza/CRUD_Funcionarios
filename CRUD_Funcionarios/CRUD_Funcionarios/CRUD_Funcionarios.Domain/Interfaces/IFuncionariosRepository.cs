using CRUD_Funcionarios.Domain.Entities;
using CRUD_Funcionarios.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Funcionarios.Domain.Interfaces
{
    public interface IFuncionariosRepository : IBaseRepository<FuncionarioEntity>
    {
        Task<List<FuncionarioEntity>> GetAllFuncionarioByDepartamento (DepartamentoEnum departamento, CancellationToken cancellationToken);
        Task<List<FuncionarioEntity>> GetAllFuncionarioByTurno (TurnoEnum turno, CancellationToken cancellationToken);
        Task<FuncionarioEntity> GetFuncionarioByCPF (string cpf, CancellationToken cancellationToken);
        Task<FuncionarioEntity> GetFuncionarioByEmail(string email, CancellationToken cancellationToken);
    }
}
