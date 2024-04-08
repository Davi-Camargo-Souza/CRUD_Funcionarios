using CRUD_Funcionarios.Domain.Entities;
using CRUD_Funcionarios.Domain.Enums;
using CRUD_Funcionarios.Domain.Exceptions;
using CRUD_Funcionarios.Domain.Interfaces;
using CRUD_Funcionarios.DTOs;
using CRUD_Funcionarios.WebAPI.Shared.Behavior;

namespace CRUD_Funcionarios.WebAPI.Services.Funcionario
{
    public class FuncionariosService : FuncionariosServiceInterface
    {
        private readonly IFuncionariosRepository _funcionariosRepository;
        private readonly IUnitOfWork _unitOfWork;

        public FuncionariosService(IFuncionariosRepository funcionariosRepository, IUnitOfWork unitOfWork)
        {
            _funcionariosRepository = funcionariosRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse<List<FuncionarioEntity>>> CreateFuncionario(FuncionarioEntity novoFuncionario, CancellationToken cancellationToken)
        {
            ServiceResponse<List<FuncionarioEntity>> serviceResponse = new ServiceResponse<List<FuncionarioEntity>>();

            try
            {
                var entity = await _funcionariosRepository.GetFuncionarioByEmail(novoFuncionario.Email, cancellationToken);
                if (entity != null) throw new EmailJaCadastradoException();

                entity = await _funcionariosRepository.GetFuncionarioByCPF(novoFuncionario.CPF, cancellationToken);
                if (entity != null) throw new CPFJaCadastradoException();

                _funcionariosRepository.Create(novoFuncionario, cancellationToken);
                await _unitOfWork.Commit(cancellationToken);

                serviceResponse.Dados = await _funcionariosRepository.GetAll("Funcionarios", cancellationToken);
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioEntity>>> DeleteFuncionario(Guid id, CancellationToken cancellationToken)
        {
            ServiceResponse<List<FuncionarioEntity>> serviceResponse = new ServiceResponse<List<FuncionarioEntity>>();

            try
            {
                var entity = await _funcionariosRepository.Get(id, "Funcionarios", cancellationToken);
                _funcionariosRepository.Delete(entity);
                await _unitOfWork.Commit(cancellationToken);
                serviceResponse.Dados = await _funcionariosRepository.GetAll("Funcionarios", cancellationToken);
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioEntity>>> GetAllFuncionarios(CancellationToken cancellationToken)
        {
            ServiceResponse<List<FuncionarioEntity>> serviceResponse = new ServiceResponse<List<FuncionarioEntity>>();

            try
            {
                serviceResponse.Dados = await _funcionariosRepository.GetAll("Funcionarios", cancellationToken);
            }
            catch(Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioEntity>>> GetAllFuncionariosAtivos(CancellationToken cancellationToken)
        {
            ServiceResponse<List<FuncionarioEntity>> serviceResponse = new ServiceResponse<List<FuncionarioEntity>>();

            try
            {
                serviceResponse.Dados = await _funcionariosRepository.GetAllAtivos("Funcionarios", cancellationToken);
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioEntity>>> GetAllFuncionariosInativos(CancellationToken cancellationToken)
        {
            ServiceResponse<List<FuncionarioEntity>> serviceResponse = new ServiceResponse<List<FuncionarioEntity>>();

            try
            {
                serviceResponse.Dados = await _funcionariosRepository.GetAllInativos("Funcionarios", cancellationToken);
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<FuncionarioEntity>> GetFuncionarioById(Guid id, CancellationToken cancellationToken)
        {
            ServiceResponse<FuncionarioEntity> serviceResponse = new ServiceResponse<FuncionarioEntity>();

            try
            {
                serviceResponse.Dados = await _funcionariosRepository.Get(id, "Funcionarios", cancellationToken);
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioEntity>>> GetAllFuncionariosByTurno(TurnoEnum turno, CancellationToken cancellationToken)
        {
            ServiceResponse<List<FuncionarioEntity>> serviceResponse = new ServiceResponse<List<FuncionarioEntity>>();

            try
            {
                serviceResponse.Dados = await _funcionariosRepository.GetAllFuncionarioByTurno(turno, cancellationToken);
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioEntity>>> GetAllFuncionariosByDepartamento(DepartamentoEnum departamento, CancellationToken cancellationToken)
        {
            ServiceResponse<List<FuncionarioEntity>> serviceResponse = new ServiceResponse<List<FuncionarioEntity>>();

            try
            {
                serviceResponse.Dados = await _funcionariosRepository.GetAllFuncionarioByDepartamento(departamento, cancellationToken);
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioEntity>>> InativaFuncionario(Guid id, CancellationToken cancellationToken)
        {
            ServiceResponse<List<FuncionarioEntity>> serviceResponse = new ServiceResponse<List<FuncionarioEntity>>();

            try
            {
                _funcionariosRepository.Inativar(id, "Funcionarios", cancellationToken);
                await _unitOfWork.Commit(cancellationToken);
                serviceResponse.Dados = await _funcionariosRepository.GetAll("Funcionarios", cancellationToken);
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioEntity>>> UpdateFuncionario(FuncionarioEntity funcionarioEditado, CancellationToken cancellationToken)
        {
            ServiceResponse<List<FuncionarioEntity>> serviceResponse = new ServiceResponse<List<FuncionarioEntity>>();

            try
            {
                var entity = _funcionariosRepository.Get(funcionarioEditado.Id, "Funcionarios", cancellationToken);

                var consulta = _funcionariosRepository.GetFuncionarioByEmail(funcionarioEditado.Email, cancellationToken);
                if (consulta.Result != null)
                {
                    if (consulta.Result.CPF != entity.Result.CPF) throw new EmailJaCadastradoException();

                }
                _funcionariosRepository.Update(funcionarioEditado);
                await _unitOfWork.Commit(cancellationToken);
                serviceResponse.Dados = await _funcionariosRepository.GetAll("Funcionarios", cancellationToken);
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<FuncionarioEntity>> GetFuncionarioByCPF(string cpf, CancellationToken cancellationToken)
        {
            ServiceResponse<FuncionarioEntity> serviceResponse = new ServiceResponse<FuncionarioEntity>();

            try
            {
                serviceResponse.Dados = await _funcionariosRepository.GetFuncionarioByCPF(cpf, cancellationToken);
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<FuncionarioEntity>> GetFuncionarioByEmail(string email, CancellationToken cancellationToken)
        {
            ServiceResponse<FuncionarioEntity> serviceResponse = new ServiceResponse<FuncionarioEntity>();

            try
            {
                serviceResponse.Dados = await _funcionariosRepository.GetFuncionarioByEmail(email, cancellationToken);
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioEntity>>> AtivaFuncionario(Guid id, CancellationToken cancellationToken)
        {
            ServiceResponse<List<FuncionarioEntity>> serviceResponse = new ServiceResponse<List<FuncionarioEntity>>();

            try
            {
                _funcionariosRepository.Ativar(id, "Funcionarios", cancellationToken);
                await _unitOfWork.Commit(cancellationToken);
                serviceResponse.Dados = await _funcionariosRepository.GetAll("Funcionarios", cancellationToken);
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }
    }
}
