using CRUD_Funcionarios.Domain.Entities;
using CRUD_Funcionarios.Domain.Enums;
using CRUD_Funcionarios.DTOs;

namespace CRUD_Funcionarios.WebAPI.Services.Funcionario
{
    public interface FuncionariosServiceInterface
    {
        Task<ServiceResponse<List<FuncionarioEntity>>> GetAllFuncionarios(CancellationToken cancellationToken);
        Task<ServiceResponse<List<FuncionarioEntity>>> GetAllFuncionariosAtivos(CancellationToken cancellationToken);
        Task<ServiceResponse<List<FuncionarioEntity>>> GetAllFuncionariosInativos(CancellationToken cancellationToken);
        Task<ServiceResponse<List<FuncionarioEntity>>> GetAllFuncionariosByTurno(TurnoEnum turno, CancellationToken cancellationToken);
        Task<ServiceResponse<List<FuncionarioEntity>>> GetAllFuncionariosByDepartamento(DepartamentoEnum departamento, CancellationToken cancellationToken);
        Task<ServiceResponse<FuncionarioEntity>> GetFuncionarioByCPF(string cpf, CancellationToken cancellationToken);
        Task<ServiceResponse<FuncionarioEntity>> GetFuncionarioByEmail(string email, CancellationToken cancellationToken);
        Task<ServiceResponse<FuncionarioEntity>> GetFuncionarioById(Guid id, CancellationToken cancellationToken);
        Task<ServiceResponse<List<FuncionarioEntity>>> CreateFuncionario (FuncionarioEntity novoFuncionario, CancellationToken cancellationToken);
        Task<ServiceResponse<List<FuncionarioEntity>>> UpdateFuncionario (FuncionarioEntity funcionarioEditado, CancellationToken cancellationToken);
        Task<ServiceResponse<List<FuncionarioEntity>>> DeleteFuncionario (Guid id, CancellationToken cancellationToken);
        Task<ServiceResponse<List<FuncionarioEntity>>> InativaFuncionario (Guid id, CancellationToken cancellationToken);
        Task<ServiceResponse<List<FuncionarioEntity>>> AtivaFuncionario (Guid id, CancellationToken cancellationToken);


    }
}
