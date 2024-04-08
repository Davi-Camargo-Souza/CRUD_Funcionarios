using CRUD_Funcionarios.Domain.Entities;
using CRUD_Funcionarios.Domain.Enums;
using CRUD_Funcionarios.Domain.Interfaces;
using CRUD_Funcionarios.DTOs;
using CRUD_Funcionarios.WebAPI.Services.Funcionario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Funcionarios.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly FuncionariosServiceInterface _funcionariosService;

        public FuncionarioController(FuncionariosServiceInterface funcionariosService)
        {
            _funcionariosService = funcionariosService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioEntity>>>> GetAllFuncionarios(CancellationToken cancellationToken)
        {
            return Ok(await _funcionariosService.GetAllFuncionarios(cancellationToken));
        }

        [HttpGet("Id")]
        public async Task<ActionResult<ServiceResponse<FuncionarioEntity>>> GetFuncionarioById(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await _funcionariosService.GetFuncionarioById(id, cancellationToken));
        }

        [HttpGet("Email")]
        public async Task<ActionResult<ServiceResponse<FuncionarioEntity>>> GetFuncionarioByEmail(string email, CancellationToken cancellationToken)
        {
            return Ok(await _funcionariosService.GetFuncionarioByEmail(email, cancellationToken));
        }

        [HttpGet("CPF")]
        public async Task<ActionResult<ServiceResponse<FuncionarioEntity>>> GetFuncionarioByCPF(string cpf, CancellationToken cancellationToken)
        {
            return Ok(await _funcionariosService.GetFuncionarioByCPF(cpf, cancellationToken));
        }

        [HttpGet("Ativos")]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioEntity>>>> GetAllFuncionariosAtivos(CancellationToken cancellationToken)
        {
            return Ok(await _funcionariosService.GetAllFuncionariosAtivos(cancellationToken));
        }

        [HttpGet("Inativos")]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioEntity>>>> GetAllFuncionariosInativos(CancellationToken cancellationToken)
        {
            return Ok(await _funcionariosService.GetAllFuncionariosInativos(cancellationToken));
        }

        [HttpGet("Inativar")]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioEntity>>>> InativarFuncionario(Guid id, CancellationToken cancellationToken) 
        {
            return Ok(await _funcionariosService.InativaFuncionario(id, cancellationToken));
        }

        [HttpGet("Ativar")]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioEntity>>>> AtivarFuncionario(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await _funcionariosService.AtivaFuncionario(id, cancellationToken));
        }

        [HttpGet("AllFuncionariosByTurno")]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioEntity>>>> GetAllFuncionariosByTurno(TurnoEnum turno,CancellationToken cancellationToken)
        {
            return Ok(await _funcionariosService.GetAllFuncionariosByTurno(turno, cancellationToken));
        }

        [HttpGet("AllFuncionariosByDepartamento")]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioEntity>>>> GetAllFuncionariosByDepartamento(DepartamentoEnum departamento, CancellationToken cancellationToken)
        {
            return Ok(await _funcionariosService.GetAllFuncionariosByDepartamento(departamento, cancellationToken));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioEntity>>>> CreateFuncionario(FuncionarioEntity funcionario, CancellationToken cancellationToken)
        {
            return Ok(await _funcionariosService.CreateFuncionario(funcionario, cancellationToken));
        }

        [HttpPost("UpdateFuncionario")]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioEntity>>>> UpdateFuncionario (FuncionarioEntity funcionario, CancellationToken cancellationToken)
        {
            return Ok(await _funcionariosService.UpdateFuncionario(funcionario, cancellationToken));
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioEntity>>>> DeleteFuncionario(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await _funcionariosService.DeleteFuncionario(id, cancellationToken));
        }

        

    }
}
